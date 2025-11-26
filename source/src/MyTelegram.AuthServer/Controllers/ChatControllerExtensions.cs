using Microsoft.AspNetCore.Mvc;
using MyTelegram.Schema.Payments;

namespace MyTelegram.AuthServer.Controllers;

[ApiController]
[Route(""/api/chat"")]
public class ChatControllerExtensions : ControllerBase
{
    [HttpPost(""sendPremiumGift"")]
    public async Task<IActionResult> SendPremiumGift([FromBody] PaymentsSendGiftPremium req)
    {
        var handler = new MyTelegram.Services.Handlers.SendGiftPremiumHandler();
        var result = await handler.Handle(req);
        return Ok(result);
    }
}
