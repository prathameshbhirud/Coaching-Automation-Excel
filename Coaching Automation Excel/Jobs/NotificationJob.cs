using CoachingAutomationExcel.Services;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Jobs;

public class NotificationJob
{
    private readonly ExcelService _excel;
    private readonly WhatsAppService _whatsapp;
    private readonly TelegramService _telegram;
    private readonly ILogger<NotificationJob> _logger;
    private readonly MessageTemplateService _templates;

    public NotificationJob(
        ExcelService excel,
        WhatsAppService whatsapp,
        TelegramService telegram,
        ILogger<NotificationJob> logger,
        MessageTemplateService templates)
    {
        _excel = excel;
        _whatsapp = whatsapp;
        _telegram = telegram;
        _logger = logger;
        _templates = templates;
    }

    // =========================
    // ATTENDANCE
    // =========================
    public async Task<NotificationResultDto> RunAttendanceNotifications()
    {
        var result = new NotificationResultDto
        {
            Module = "Attendance",
            ExecutedAt = DateTime.Now
        };

        var students = _excel.GetAttendanceStudents();

        foreach(var s in students)
        {
            if(s.Attendance?.ToLower() != "absent")
                continue;

            result.Processed++;

            try
            {
                var msg =_templates.GetAttendanceMessage(s);
                await SendMessage(s, msg);
                result.Sent++;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed attendance notification");
                result.Failed++;
            }
        }
        return result;
    }

    // =========================
    // FEES
    // =========================
    public async Task<NotificationResultDto> RunFeeReminders()
    {
        _logger.LogInformation("Starting fee reminders");

        var result = new NotificationResultDto
        {
            Module = "Fees",
            ExecutedAt = DateTime.Now
        };

        var students = _excel.GetFeesStudents();

        foreach (var student in students)
        {
            if (student.FeesDue <= 0)
                continue;

            result.Processed++;

            try
            {
                var message = _templates.GetFeesReminder(student);

                switch (student.PreferredChannel)
                {
                    case NotificationChannel.WhatsApp:
                        _whatsapp.Send(student.ParentPhone, message);
                        break;

                    case NotificationChannel.Telegram:
                        await _telegram.Send(message);
                        break;
                }

                result.Sent++;

                _logger.LogInformation("Fee reminder sent to {Student}", student.StudentName);
            }
            catch (Exception ex)
            {
                result.Failed++;
                _logger.LogError(ex, "Failed fee reminder for {Student}", student.StudentName);
            }
        }

        _logger.LogInformation("Completed fee reminders. Sent={Sent}, Failed={Failed}", result.Sent, result.Failed);
        return result;
    }

    // =========================
    // EXAMS
    // =========================
    public async Task<NotificationResultDto> RunExamReminders()
    {
        _logger.LogInformation("Starting exam reminders");

        var result = new NotificationResultDto
        {
            Module = "Exams",
            ExecutedAt = DateTime.Now
        };

        var students = _excel.GetExamStudents();

        foreach (var student in students)
        {
            if (student.ExamDate < DateTime.Today)
                continue;

            result.Processed++;

            try
            {
                var message = _templates.GetExamReminder(student);

                switch (student.PreferredChannel)
                {
                    case NotificationChannel.WhatsApp:
                        _whatsapp.Send(student.ParentPhone, message);
                        break;

                    case NotificationChannel.Telegram:
                        await _telegram.Send(message);
                        break;
                }

                result.Sent++;

                _logger.LogInformation("Exam reminder sent to {Student}", student.StudentName);
            }
            catch (Exception ex)
            {
                result.Failed++;
                _logger.LogError(ex, "Failed exam reminder for {Student}", student.StudentName);
            }
        }

        _logger.LogInformation("Completed exam reminders. Sent={Sent}, Failed={Failed}", result.Sent, result.Failed);
        return result;
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
    public async Task<NotificationResultDto> RunBroadcasts()
    {
        _logger.LogInformation("Starting broadcasts");

        var result = new NotificationResultDto
        {
            Module = "Broadcast",
            ExecutedAt = DateTime.Now
        };

        var broadcasts = _excel.GetBroadcastMessages();

        foreach (var broadcast in broadcasts)
        {
            result.Processed++;

            try
            {
                var message =_templates.GetBroadcastMessage(broadcast.Message);

                switch (broadcast.PreferredChannel)
                {
                    case NotificationChannel.WhatsApp:
                        _whatsapp.Send("+91<YOUR_TEST_NUMBER>", message);
                        break;

                    case NotificationChannel.Telegram:
                        await _telegram.Send(message);
                        break;
                }

                result.Sent++;
                _logger.LogInformation("Broadcast sent successfully");
            }
            catch (Exception ex)
            {
                result.Failed++;
                _logger.LogError(ex, "Failed broadcast");
            }
        }

        _logger.LogInformation("Completed broadcasts. Sent={Sent}, Failed={Failed}", result.Sent, result.Failed);
        return result;
    }
}