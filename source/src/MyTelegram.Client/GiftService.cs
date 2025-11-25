
using MyTelegram.Schema.Payments;

namespace MyTelegram.Client;

public class GiftService
{
    private readonly ITelegramClient _client;
    public GiftService(ITelegramClient client) => _client = client;

    public async Task SendPremiumGiftAsync(InputUser user, string message)
    {
        await _client.PaymentsSendGiftPremiumAsync(new PaymentsSendGiftPremium
        {
            User = user,
            Currency = "USD",
            Amount = 0,
            Message = message
        });
    }
}
