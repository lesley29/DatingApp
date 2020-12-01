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
    public class GetMembersWhoLikedUserQuery : IRequest<List<MemberSummary>>
    {
        public GetMembersWhoLikedUserQuery(IAuthenticatedUser user)
        {
            User = user;
        }

        public IAuthenticatedUser User { get;  }
    }

    public class GetMembersWhoLikedUserQueryHandler : IRequestHandler<GetMembersWhoLikedUserQuery, List<MemberSummary>>
    {
        private readonly IDatingAppDbContext _dbContext;

        public GetMembersWhoLikedUserQueryHandler(IDatingAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<MemberSummary>> Handle(GetMembersWhoLikedUserQuery request, CancellationToken cancellationToken)
        {
            return _dbContext.Users.Where(su =>
                    _dbContext.Users
                        .SelectMany(u => u.UserLikes)
                        .Where(ul => ul.TargetUserId == request.User.Id)
                        .Select(ul => ul .SourceUserId)
                        .Contains(su.Id))
                .Select(u => new MemberSummary(u.Id, u.Name, u.City, u.Photos.FirstOrDefault(p => p.IsMain)))
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
