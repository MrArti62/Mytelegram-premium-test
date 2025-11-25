
namespace MyTelegram.Schema.Payments;
public sealed class PaymentsSendGiftPremium : IRequest<IUpdates>
{
    public required InputUser User { get; init; }
    public required string Currency { get; init; }
    public required long Amount { get; init; }
    public string? Message { get; init; }
}
