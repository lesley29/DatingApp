using System.Threading.Tasks;

namespace API.Realtime.Presence
{
    public interface IPresenceClient
    {
        Task UserConnected(string user);

        Task UserDisconnected(string user);
    }
}
