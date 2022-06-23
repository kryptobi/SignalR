using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest;

public class TestController : Controller
{
    private readonly IHubContext<HubMethods> _hubContext;

    public TestController(IHubContext<HubMethods> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<IActionResult> Index(
        [FromQuery] string userName,
        CancellationToken cancellationToken)
    {
        await _hubContext.Clients.All.SendAsync("SendMessage", userName, cancellationToken);
        return Ok();
    }
}