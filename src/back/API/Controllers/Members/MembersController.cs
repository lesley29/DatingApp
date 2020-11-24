using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Members.Queries;
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
        public Task<List<MemberDto>> List(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetMemberListQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        public Task<MemberDto> Get(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetMemberQuery(id), cancellationToken);
        }
    }
}
