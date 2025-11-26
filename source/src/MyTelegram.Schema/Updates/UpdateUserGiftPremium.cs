namespace MyTelegram.Schema.Updates;
public sealed class UpdateUserGiftPremium : IUpdate
{
    public int UserId { get; init; }
    public int Months { get; init; }
    public string? Message { get; init; }
    public int ChatId { get; init; }
}
