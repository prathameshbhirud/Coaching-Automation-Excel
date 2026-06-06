namespace CoachingAutomationExcel.Entities;

public class AppSetting
{
    public int Id { get; set; }

    public string CoachingName { get; set; } = string.Empty;

    public string TwilioSid { get; set; } = string.Empty;

    public string TwilioToken { get; set; } = string.Empty;

    public string TwilioNumber { get; set; } = string.Empty;

    public string TelegramBotToken { get; set; } = string.Empty;

    public string TelegramChatId { get; set; } = string.Empty;

    public bool AttendanceEnabled { get; set; } = true;

    public bool FeesEnabled { get; set; } = true;

    public bool ExamsEnabled { get; set; } = true;

    public bool BroadcastEnabled { get; set; } = true;
}