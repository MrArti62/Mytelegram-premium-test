
using MyTelegram.Client;

namespace MyTelegram.UI;

public class GiftScreen
{
    private readonly GiftService _giftService;
    public GiftScreen(GiftService giftService) => _giftService = giftService;

    public async Task OnSendButtonClicked(InputUser user, string message)
    {
        await _giftService.SendPremiumGiftAsync(user, message);
        Console.WriteLine("Premium Gift Sent!");
    }
}
