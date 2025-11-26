using MyTelegram.Schema.MessageActions;

namespace MyTelegram.UI.Renderers;
public class PremiumGiftBubbleRenderer
{
    public PremiumGiftBubbleModel CreateModel(dynamic messageRecord)
    {
        return new PremiumGiftBubbleModel
        {
            MessageId = (long)messageRecord.GetProperty("Id").GetInt64(),
            FromUserId = (int)messageRecord.GetProperty("FromUserId").GetInt32(),
            ChatId = (int)messageRecord.GetProperty("ChatId").GetInt32(),
            Months = (int)messageRecord.GetProperty("Months").GetInt32(),
            Note = messageRecord.GetProperty("Note").GetString() ?? string.Empty,
            Title = $"Premium for {messageRecord.GetProperty("Months").GetInt32()} months"
        };
    }
}

public class PremiumGiftBubbleModel
{
    public long MessageId { get; set; }
    public int FromUserId { get; set; }
    public int ChatId { get; set; }
    public int Months { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
}
