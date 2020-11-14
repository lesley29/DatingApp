using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController
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
    }
}
