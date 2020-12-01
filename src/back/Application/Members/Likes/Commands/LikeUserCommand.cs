using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Persistence;
using Application.Users;
using Domain.Aggregates.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Members.Likes.Commands
{
    public class LikeUserCommand : IRequest
    {
        public LikeUserCommand(IAuthenticatedUser user, int targetUserId)
        {
            User = user;
            TargetUserId = targetUserId;
        }

        public IAuthenticatedUser User { get; }

        public int TargetUserId { get; }
    }

    public class LikeUserCommandHandler : AsyncRequestHandler<LikeUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IDatingAppDbContext _dbContext;

        public LikeUserCommandHandler(IUserRepository userRepository, IDatingAppDbContext dbContext)
        {
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        protected override async Task Handle(LikeUserCommand request, CancellationToken cancellationToken)
        {
            if (!await _dbContext.Users.AnyAsync(u => u.Id == request.TargetUserId, cancellationToken))
            {
                throw new ResourceNotFoundException();
            }

            var user = await _userRepository.SingleOrDefault(u => u.Id == request.User.Id, cancellationToken);

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            user.Like(request.TargetUserId);
        }
    }
}
