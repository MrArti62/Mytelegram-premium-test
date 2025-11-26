using System.IO;
using System.Text.Json;
using MyTelegram.Schema.Payments;
using MyTelegram.Schema.Updates;
using MyTelegram.Schema.MessageActions;

namespace MyTelegram.Services.Handlers;

public class SendGiftPremiumHandler
{
    private readonly string _dataFolder;

    public SendGiftPremiumHandler(string dataFolder = null)
    {
        _dataFolder = dataFolder ?? Path.Combine(Directory.GetCurrentDirectory(), "data", "messages");
        Directory.CreateDirectory(_dataFolder);
    }

    public async Task<object> Handle(PaymentsSendGiftPremium req)
    {
        // Create a message action representing the gift
        var action = new MessageActionGiftPremium
        {
            Months = 3,
            Title = $"Premium for 3 months",
            Note = req.Message,
            FromUserId = req.User.UserId,
            ToChatId = req.ChatId
        };

        var update = new UpdateUserGiftPremium
        {
            UserId = req.User.UserId,
            Months = action.Months,
            Message = action.Note,
            ChatId = req.ChatId
        };

        // Persist as a message object in a simple JSON file per chat
        var chatFile = Path.Combine(_dataFolder, $"chat_{req.ChatId}.json");
        List<object> list = new();
        if (File.Exists(chatFile))
        {
            try
            {
                var existing = await File.ReadAllTextAsync(chatFile);
                list = JsonSerializer.Deserialize<List<object>>(existing) ?? new List<object>();
            }
            catch { list = new List<object>(); }
        }

        var messageRecord = new {
            Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            FromUserId = req.User.UserId,
            ChatId = req.ChatId,
            Action = "gift_premium",
            Months = action.Months,
            Note = action.Note,
            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        };

        list.Add(messageRecord);
        var json = JsonSerializer.Serialize(list, new JsonSerializerOptions{WriteIndented=true});
        await File.WriteAllTextAsync(chatFile, json);

        // Return a minimal updates DTO — adapt to your IUpdates/TUpdates in real project
        return new { Update = update, Message = messageRecord };
    }
}
