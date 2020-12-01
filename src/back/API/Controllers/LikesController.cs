using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.CrossCutting.Auth;
using Application.Members.Likes.Commands;
using Application.Members.Likes.Queries;
using Application.Members.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("likes")]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{userId}")]
        public Task Like(int userId, CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new LikeUserCommand(user, userId), cancellationToken);
        }

        [HttpGet]
        public Task<List<MemberSummary>> GetLiked(CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new GetMembersLikedByUserQuery(user), cancellationToken);
        }

        [HttpGet("liked-current")]
        public Task<List<MemberSummary>> GetWhoLikedCurrent(CancellationToken cancellationToken)
        {
            var user = new AuthenticatedUser(User);

            return _mediator.Send(new GetMembersWhoLikedUserQuery(user), cancellationToken);
        }
    }
}
