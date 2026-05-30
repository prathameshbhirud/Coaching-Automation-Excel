using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Jobs;

public class NotificationJob
{
    private readonly ExcelService _excel;
    private readonly WhatsAppService _whatsapp;
    private readonly TelegramService _telegram;
    private readonly ILogger<NotificationJob> _logger;

    public NotificationJob(
        ExcelService excel,
        WhatsAppService whatsapp,
        TelegramService telegram,
        ILogger<NotificationJob> logger)
    {
        _excel = excel;
        _whatsapp = whatsapp;
        _telegram = telegram;
        _logger = logger;
    }

    // =========================
    // ATTENDANCE
    // =========================
    public async Task RunAttendanceNotifications()
    {
        _logger.LogInformation("Running Attendance Notifications");
        var students = _excel.GetAttendanceStudents();

        foreach (var s in students)
        {
            if (s.Attendance.ToLower() == "absent")
            {
                var msg = $"{s.StudentName} was absent today.";

                _logger.LogInformation("Sending Attendance Notifications...");

                await SendMessage(s, msg);

                _logger.LogInformation("Attendance Notifications sent.");
            }
        }
    }

    // =========================
    // FEES
    // =========================
    public async Task RunFeeReminders()
    {
        _logger.LogInformation("Running Fees Reminders");

        var students = _excel.GetFeesStudents();

        foreach (var s in students)
        {
            if (s.FeesDue > 0)
            {
                var msg = $"Fees pending: ₹{s.FeesDue}";

                _logger.LogInformation("Sending Fees Reminders...");

                await SendMessage(s, msg);

                _logger.LogInformation("Fees Reminders sent.");
            }
        }
    }

    // =========================
    // EXAMS
    // =========================
    public async Task RunExamReminders()
    {
        _logger.LogInformation("Running Exams Reminders");

        var students = _excel.GetExamStudents();

        foreach (var s in students)
        {
            var examDateText = s.ExamDate?.ToString("dd MMM yyyy") ?? "TBD";

            var msg = $"Upcoming Exam: {s.ExamName} on {examDateText}";

           _logger.LogInformation("Sending Exams Reminders...");

            await SendMessage(s, msg);

            _logger.LogInformation("Exams Reminders sent.");
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

    // =========================
    // BROADCAST
    // =========================
    public async Task RunBroadcasts()
    {
        _logger.LogInformation("Starting broadcast messages");

        var broadcasts = _excel.GetBroadcastMessages();

        foreach (var b in broadcasts)
        {
            try
            {
                _logger.LogInformation(
                    "Sending broadcast: {Message}",
                    b.Message);

                if (b.PreferredChannel == NotificationChannel.WhatsApp)
                {
                    // SEND TO YOUR TEST NUMBER
                    // TODO: update list of bulk recipients
                    _whatsapp.Send(
                        "+91<YOUR_TEST_NUMBER>",
                        b.Message);
                }
                else
                {
                    await _telegram.Send(b.Message);
                }

                _logger.LogInformation(
                    "Broadcast sent successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error sending broadcast");
            }
        }

        _logger.LogInformation("Completed broadcasts");
    }
}