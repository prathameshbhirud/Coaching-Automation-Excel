using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Jobs;

public class NotificationJob
{
    private readonly ExcelService _excel;
    private readonly WhatsAppService _whatsapp;
    private readonly TelegramService _telegram;

    public NotificationJob(
        ExcelService excel,
        WhatsAppService whatsapp,
        TelegramService telegram)
    {
        _excel = excel;
        _whatsapp = whatsapp;
        _telegram = telegram;
    }

    public async Task Run()
    {
        var students = _excel.GetStudents();

        foreach (var s in students)
        {
            if (s.Attendance.ToLower() == "absent")
            {
                var msg = $"{s.StudentName} was absent today.";

                if (s.PreferredChannel == NotificationChannel.WhatsApp)
                    _whatsapp.Send(s.ParentPhone, msg);
                else
                    await _telegram.Send(msg);
            }

            if (s.FeesDue > 0)
            {
                var msg = $"Fees pending: ₹{s.FeesDue}";

                if (s.PreferredChannel == NotificationChannel.WhatsApp)
                    _whatsapp.Send(s.ParentPhone, msg);
                else
                    await _telegram.Send(msg);
            }
        }
    }
}