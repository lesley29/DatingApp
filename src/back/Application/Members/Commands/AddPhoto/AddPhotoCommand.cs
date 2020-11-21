using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Application.Common.Persistence.Photos;
using Application.Users;
using Domain.Aggregates.User;
using Domain.Aggregates.User.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Members.Commands.AddPhoto
{
    public class AddPhotoCommand : IRequest
    {
        public AddPhotoCommand(IAuthenticatedUser authenticatedUser, IFormFile photo)
        {
            AuthenticatedUser = authenticatedUser;
            Photo = photo;
        }

        public IAuthenticatedUser AuthenticatedUser { get; }

        public IFormFile Photo { get; }
    }

    public class AddPhotoCommandHandler : AsyncRequestHandler<AddPhotoCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoStorage _photoStorage;

        public AddPhotoCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPhotoStorage photoStorage)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _photoStorage = photoStorage;
        }

        protected override async Task Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SingleOrDefault(
                u => u.Id == request.AuthenticatedUser.Id,
                cancellationToken
            );

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            var newPhotoName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Photo.FileName)}";
            var addPhotoRequest = new AddPhotoRequest(newPhotoName, request.Photo.OpenReadStream(), request.Photo.ContentType);
            var addPhotoResponse = await _photoStorage.Add(addPhotoRequest, cancellationToken);

            var photo = new Photo(newPhotoName, addPhotoResponse.Url);
            user.AddPhoto(photo);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
