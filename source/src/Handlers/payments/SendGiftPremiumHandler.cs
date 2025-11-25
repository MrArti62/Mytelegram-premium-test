
using MyTelegram.Schema.Payments;
using MyTelegram.Schema.Updates;

namespace MyTelegram.Handlers.Payments;

public class SendGiftPremiumHandler : RpcHandler<PaymentsSendGiftPremium, IUpdates>
{
    protected override async Task<IUpdates> HandleCoreAsync(IRequestInput input, PaymentsSendGiftPremium obj)
    {
        var update = new UpdateUserGiftPremium
        {
            UserId = obj.User.UserId,
            Months = 3,
            Message = obj.Message
        };

        return new TUpdates
        {
            Updates = new List<IUpdate> { update },
            Users = new(),
            Chats = new(),
            Date = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Seq = 0
        };
    }
}
