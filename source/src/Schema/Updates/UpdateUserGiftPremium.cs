
namespace MyTelegram.Schema.Updates;
public sealed class UpdateUserGiftPremium : IUpdate
{
    public required int UserId { get; init; }
    public required int Months { get; init; }
    public string? Message { get; init; }
}
