using System.Threading;
using System.Threading.Tasks;
using API.Auth;
using Application.Members.Commands;
using Application.Members.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Members
{
    [ApiController]
    [Route("api/members/current")]
    public class CurrentMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrentMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("info")]
        public async Task<IActionResult> UpdateInfo(UpdateMemberInfoRequest request, CancellationToken cancellationToken)
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

        [HttpPost("photos")]
        public Task<PhotoDto> AddPhoto(IFormFile formFile, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new AddPhotoCommand(user, formFile), cancellationToken);
        }

        [HttpPut("photos/main")]
        public Task SetPhotoAsMain([FromBody]string photoName, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new SetPhotoAsMainCommand(user, photoName), cancellationToken);
        }
    }
}
