using System.Threading;
using System.Threading.Tasks;
using Application.Common.Pagination;
using Application.Members.Queries.GetList;
using Application.Members.Queries.GetMember;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Members
{
    [ApiController]
    [Authorize]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public Task<PagedResponse<MemberSummary>> List(
            [FromQuery] GetMemberListQuery query,
            CancellationToken cancellationToken)
        {
            return _mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id}")]
        public Task<MemberDto> Get(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetMemberQuery(id), cancellationToken);
        }
    }
}
