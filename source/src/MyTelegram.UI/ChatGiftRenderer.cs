
using MyTelegram.Schema.Updates;

namespace MyTelegram.UI;

public class ChatGiftRenderer
{
    public string Render(UpdateUserGiftPremium update)
    {
        var months = update.Months;
        var msg = update.Message ?? "";
        return $"🎁 Premium gift for {months} months! {msg}";
    }
}
