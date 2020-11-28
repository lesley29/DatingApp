using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Pagination;
using Application.Common.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Members.Queries.GetList
{
    public class GetMemberListQuery : IRequest<PagedResponse<MemberSummary>>
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }

    internal class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, PagedResponse<MemberSummary>>
    {
        private readonly IDatingAppDbContext _datingAppDbContext;

        public GetMemberListQueryHandler(IDatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public Task<PagedResponse<MemberSummary>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
        {
            var query = _datingAppDbContext.Users
                .OrderBy(m => m.Id)
                .AsNoTracking()
                .Select(u => new MemberSummary(
                    u.Id,
                    u.Name,
                    u.City,
                    u.Photos.FirstOrDefault(p => p.IsMain)
                ));

            return PagedResponse<MemberSummary>.Create(query, request.PageNumber, request.PageSize);
        }
    }
}
