using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using WebChat.Models;

namespace WebChat.Hubs
{
    public interface IWebChatClient
    {
        public Task ReceiveMessage(string userName, string message);
    }
    public class WebChatHub : Hub<IWebChatClient>
    {
        public async Task JoinChat(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, connection.ChatRoom);
            await Clients.Group(connection.ChatRoom).ReceiveMessage("Admin", $"{connection.UserName} присоединился к чату!");

        }
    }
}
