using System.Threading.Tasks;
using API.CrossCutting.Auth;
using Application.Messages.Commands;
using Application.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.Realtime.Messages
{
    [Authorize]
    public class MessageHub : Hub<IMessageClient>
    {
        private readonly IMediator _mediator;

        public MessageHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var chatBuddyId = httpContext.Request.Query["user"].ToString();
            var groupName = GetGroupName(Context.UserIdentifier!, chatBuddyId);
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            var user = new AuthenticatedUser(httpContext.User);
            var messageThread = await _mediator.Send(new GetMessageThreadQuery(user, int.Parse(chatBuddyId)));

            await Clients.Group(groupName).ReceiveMessageThread(messageThread);

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(CreateMessageRequest request)
        {
            var httpContext = Context.GetHttpContext();
            var user = new AuthenticatedUser(httpContext.User);

            var sentMessage = await _mediator.Send(new AddMessageCommand(request.RecipientId, request.Content, user));

            var group = GetGroupName(Context.UserIdentifier!, request.RecipientId.ToString());
            await Clients.Group(group).ReceiveNewMessage(sentMessage);
        }

        private static string GetGroupName(string caller, string other)
        {
            var compareResult = string.CompareOrdinal(caller, other) < 0;

            return compareResult ? $"{caller}-{other}" : $"{other}-{caller}";
        }
    }
}
