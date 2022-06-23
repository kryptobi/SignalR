using Microsoft.AspNetCore.SignalR;

namespace SignalRTest;

public class HubMethods : Hub
{
    private Guid ContextId => Guid.NewGuid();

    public async Task ToServer(string chatId)
    {
        var message = new ChatMessage("Note",
                                ContextId,
                                chatId,
                                1,
                                "Message");

        await Clients.Group(chatId).SendAsync("SendMessage", message);
    }

    public async Task ChatEntered(string chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
    }

    public async Task ChatLeft(string chatId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
    }

    public override Task OnConnectedAsync()
    {
        //Verbinde ich mich?
        return base.OnConnectedAsync();
    }
}