using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Auth;
using Application.Members.Commands;
using Application.Members.Common;
using Application.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPut("current")]
        public async Task<IActionResult> Update(UpdateMemberInfoRequest request, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            await _mediator.Send(new UpdateMemberInfoCommand(
                    user,
                    request.BriefDescription,
                    request.LookingFor,
                    request.Interests,
                    request.City,
                    request.Country
                ), cancellationToken);

            return NoContent();
        }

        [HttpPost("current/photos")]
        public Task<PhotoDto> AddPhoto(IFormFile formFile, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new AddPhotoCommand(user, formFile), cancellationToken);
        }

        [HttpPut("current/photos/main")]
        public Task SetPhotoAsMain([FromBody]string photoName, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new SetPhotoAsMainCommand(user, photoName), cancellationToken);
        }
    }
}