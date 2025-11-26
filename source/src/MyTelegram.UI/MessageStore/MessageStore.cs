using System.IO;
using System.Text.Json;

namespace MyTelegram.UI.MessageStore;
public static class MessageStore
{
    private static string DataFolder => Path.Combine(Directory.GetCurrentDirectory(), "data", "messages");

    public static List<object> LoadChatMessages(int chatId)
    {
        Directory.CreateDirectory(DataFolder);
        var file = Path.Combine(DataFolder, $"chat_{chatId}.json");
        if (!File.Exists(file)) return new List<object>();
        var txt = File.ReadAllText(file);
        try
        {
            return JsonSerializer.Deserialize<List<object>>(txt) ?? new List<object>();
        }
        catch
        {
            return new List<object>();
        }
    }
}
