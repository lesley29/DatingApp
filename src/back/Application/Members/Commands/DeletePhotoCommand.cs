using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Application.Common.Persistence.Photos;
using Application.Users;
using Domain.Aggregates.User;
using MediatR;

namespace Application.Members.Commands
{
    public class DeletePhotoCommand : IRequest
    {
        public DeletePhotoCommand(IAuthenticatedUser authenticatedUser, string photoName)
        {
            AuthenticatedUser = authenticatedUser;
            PhotoName = photoName;
        }

        public IAuthenticatedUser AuthenticatedUser { get; }

        public string PhotoName { get; }
    }

    public class DeletePhotoCommandHandler : AsyncRequestHandler<DeletePhotoCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoStorage _photoStorage;

        public DeletePhotoCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPhotoStorage photoStorage)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _photoStorage = photoStorage;
        }

        protected override async Task Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SingleOrDefault(
                u => u.Id == request.AuthenticatedUser.Id,
                cancellationToken
            );

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            user.DeletePhoto(request.PhotoName);

            await _photoStorage.Delete(new DeletePhotoRequest(request.PhotoName), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
