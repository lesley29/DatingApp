using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Persistence;
using Application.Members.Queries.GetList;
using Application.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Members.Likes.Queries
{
    public class GetMembersLikedByUserQuery : IRequest<List<MemberSummary>>
    {
        public GetMembersLikedByUserQuery(IAuthenticatedUser user)
        {
            User = user;
        }

        public IAuthenticatedUser User { get; }
    }

    public class GetMembersLikedByUserQueryHandler : IRequestHandler<GetMembersLikedByUserQuery, List<MemberSummary>>
    {
        private readonly IDatingAppDbContext _dbContext;

        public GetMembersLikedByUserQueryHandler(IDatingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<MemberSummary>> Handle(GetMembersLikedByUserQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Users.Where(tu =>
                _dbContext.Users
                    .Where(u => u.Id == request.User.Id)
                    .SelectMany(u => u.UserLikes)
                    .Select(u => u.TargetUserId)
                    .Contains(tu.Id))
                .Select(u => new MemberSummary(u.Id, u.Name, u.City, u.Photos.FirstOrDefault(p => p.IsMain)))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
