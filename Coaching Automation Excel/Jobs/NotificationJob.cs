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

    // =========================
    // ATTENDANCE
    // =========================
    public async Task RunAttendanceNotifications()
    {
        var students = _excel.GetAttendanceStudents();

        foreach (var s in students)
        {
            if (s.Attendance.ToLower() == "absent")
            {
                var msg = $"{s.StudentName} was absent today.";

                await SendMessage(s, msg);
            }
        }
    }

    // =========================
    // FEES
    // =========================
    public async Task RunFeeReminders()
    {
        var students = _excel.GetFeesStudents();

        foreach (var s in students)
        {
            if (s.FeesDue > 0)
            {
                var msg = $"Fees pending: ₹{s.FeesDue}";

                await SendMessage(s, msg);
            }
        }
    }

    // =========================
    // EXAMS
    // =========================
    public async Task RunExamReminders()
    {
        Console.WriteLine("Running exam reminders..."); // TODO

        var students = _excel.GetExamStudents();

        foreach (var s in students)
        {
            var examDateText = s.ExamDate?.ToString("dd MMM yyyy") ?? "TBD";

            var msg = $"Upcoming Exam: {s.ExamName} on {examDateText}";

            Console.WriteLine("Message : " + msg); // TODO

            await SendMessage(s, msg);
        }
    }

    // =========================
    // COMMON MESSAGE HANDLER
    // =========================
    private async Task SendMessage(Student s, string msg)
    {
        Console.WriteLine($"Sending to {s.StudentName}");

        if (s.PreferredChannel == NotificationChannel.WhatsApp)
        {
            _whatsapp.Send(s.ParentPhone, msg);
        }
        else
        {
            await _telegram.Send(msg);
        }
    }
}