using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Application.Users;
using Domain.Aggregates.User;
using MediatR;

namespace Application.Members.Commands
{
    public class SetPhotoAsMainCommand : IRequest
    {
        public SetPhotoAsMainCommand(IAuthenticatedUser authenticatedUser, string photoName)
        {
            AuthenticatedUser = authenticatedUser;
            PhotoName = photoName;
        }

        public IAuthenticatedUser AuthenticatedUser { get; }

        public string PhotoName { get; }
    }

    public class SetPhotoAsMainCommandHandler : AsyncRequestHandler<SetPhotoAsMainCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetPhotoAsMainCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(SetPhotoAsMainCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.SingleOrDefault(u => u.Id == request.AuthenticatedUser.Id, cancellationToken);

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            user.SetPhotoAsMain(request.PhotoName);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
