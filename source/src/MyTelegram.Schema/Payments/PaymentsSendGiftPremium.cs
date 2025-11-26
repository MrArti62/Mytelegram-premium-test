namespace MyTelegram.Schema.Payments;
public sealed class PaymentsSendGiftPremium : IRequest<IUpdates>
{
    public InputUser User { get; init; }
    public string Currency { get; init; } = "USD";
    public long Amount { get; init; }
    public string? Message { get; init; }
    public int ChatId { get; init; } // target chat to deliver the gift message
}
