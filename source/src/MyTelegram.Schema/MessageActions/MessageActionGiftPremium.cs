namespace MyTelegram.Schema.MessageActions;

public sealed class MessageActionGiftPremium : IMessageAction
{
    public int Months { get; init; }
    public string? Title { get; init; }
    public string? Note { get; init; }
    public int FromUserId { get; init; }
    public int ToChatId { get; init; }
}
