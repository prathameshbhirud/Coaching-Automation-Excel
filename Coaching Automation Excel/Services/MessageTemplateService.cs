using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class MessageTemplateService
{
    // =========================
    // ATTENDANCE
    // =========================
    public string GetAttendanceMessage(Student s)
    {
        return $"""
        Dear Parent,

        {s.StudentName} was absent for today's lecture.

        - ABC Coaching Classes
        """;
    }

    // =========================
    // FEES
    // =========================
    public string GetFeesReminder(Student s)
    {
        return $"""
        Dear Parent,

        Fees of ₹{s.FeesDue} are pending for {s.StudentName}.

        Kindly complete payment at the earliest.

        - ABC Coaching Classes
        """;
    }

    // =========================
    // EXAMS
    // =========================
    public string GetExamReminder(Student s)
    {
        var examDate =
            s.ExamDate?.ToString("dd MMM yyyy") ?? "TBD";

        return $"""
        Dear Student,

        Upcoming Exam:
        {s.ExamName}

        Date: {examDate}

        - ABC Coaching Classes
        """;
    }

    // =========================
    // BROADCAST
    // =========================
    public string GetBroadcastMessage(string message)
    {
        return $"""
        Dear Students,

        {message}

        - ABC Coaching Classes
        """;
    }
}