using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;

namespace API.Realtime.Messages
{
    public interface IMessageClient
    {
        Task ReceiveMessageThread(List<MessageDto> messages);

        Task ReceiveNewMessage(MessageDto message);
    }
}
