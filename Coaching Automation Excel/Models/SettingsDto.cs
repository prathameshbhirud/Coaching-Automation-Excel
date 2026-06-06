public class SettingsDto
{
    public string CoachingName { get; set; } = string.Empty;

    public string TwilioSid { get; set; } = string.Empty;

    public string TwilioToken { get; set; } = string.Empty;

    public string TwilioNumber { get; set; } = string.Empty;

    public string TelegramBotToken { get; set; } = string.Empty;

    public string TelegramChatId { get; set; } = string.Empty;

    public bool AttendanceEnabled { get; set; }

    public bool FeesEnabled { get; set; }

    public bool ExamsEnabled { get; set; }

    public bool BroadcastEnabled { get; set; }
}