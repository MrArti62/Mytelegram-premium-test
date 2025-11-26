using System.Net.Http;
using System.Net.Http.Json;
using MyTelegram.Schema.Payments;

namespace MyTelegram.Client;
public class GiftService
{
    private readonly HttpClient _http;
    private readonly ITelegramClient _client;
    public GiftService(HttpClient http, ITelegramClient client = null)
    {
        _http = http;
        _client = client;
    }

    public async Task SendPremiumGiftAsync(InputUser user, int chatId, string? message = null)
    {
        var req = new PaymentsSendGiftPremium
        {
            User = user,
            Amount = 0,
            Message = message,
            ChatId = chatId
        };

        // prefer server HTTP endpoint if available
        try
        {
            var resp = await _http.PostAsJsonAsync("/api/chat/sendPremiumGift", req);
            resp.EnsureSuccessStatusCode();
            return;
        }
        catch
        {
            if (_client != null)
            {
                // fallback to raw MT client if present
                await _client.PaymentsSendGiftPremiumAsync(req);
            }
        }
    }
}
