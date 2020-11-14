using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Persistence;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Members
{
    public class GetMemberListQuery : IRequest<List<MemberDto>>
    {
    }

    public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, List<MemberDto>>
    {
        private readonly IDatingAppDbContext _datingAppDbContext;

        public GetMemberListQueryHandler(IDatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public Task<List<MemberDto>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
        {
            return _datingAppDbContext.Users
                .AsNoTracking()
                .ProjectToType<MemberDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
