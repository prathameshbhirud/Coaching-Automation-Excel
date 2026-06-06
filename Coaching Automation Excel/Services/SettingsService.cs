using CoachingAutomationExcel.Data;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class SettingsService
{
    private readonly CoachingDbContext _db;

    public SettingsService(CoachingDbContext db)
    {
        _db = db;
    }

    public SettingsDto Get()
    {
        var setting = _db.AppSettings.First();

        return new SettingsDto
        {
            CoachingName = setting.CoachingName,
            TwilioSid = setting.TwilioSid,
            TwilioToken = setting.TwilioToken,
            TwilioNumber = setting.TwilioNumber,
            TelegramBotToken = setting.TelegramBotToken,
            TelegramChatId = setting.TelegramChatId,
            AttendanceEnabled = setting.AttendanceEnabled,
            FeesEnabled = setting.FeesEnabled,
            ExamsEnabled = setting.ExamsEnabled,
            BroadcastEnabled = setting.BroadcastEnabled
        };
    }

    public void Save(SettingsDto dto)
    {
        var setting = _db.AppSettings.First();

        setting.CoachingName = dto.CoachingName;
        setting.TwilioSid = dto.TwilioSid;
        setting.TwilioToken = dto.TwilioToken;
        setting.TwilioNumber = dto.TwilioNumber;
        setting.TelegramBotToken = dto.TelegramBotToken; 
        setting.TelegramChatId = dto.TelegramChatId;
        setting.AttendanceEnabled = dto.AttendanceEnabled;
        setting.FeesEnabled = dto.FeesEnabled;
        setting.ExamsEnabled = dto.ExamsEnabled;
        setting.BroadcastEnabled = dto.BroadcastEnabled;

        _db.SaveChanges();
    }
}