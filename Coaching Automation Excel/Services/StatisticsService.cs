using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class StatisticsService
{
    private readonly NotificationStatsDto _stats = new();

    private readonly List<AttendanceTrendDto> _trend =
    [
        new() { Date = "Mon", Count = 12 },
        new() { Date = "Tue", Count = 15 },
        new() { Date = "Wed", Count = 8 },
        new() { Date = "Thu", Count = 18 },
        new() { Date = "Fri", Count = 11 }
    ];

    public void AddAttendance(int count)
    {
        _stats.AttendanceMessages += count;
    }

    public void AddFees(int count)
    {
        _stats.FeeReminders += count;
    }

    public void AddExams(int count)
    {
        _stats.ExamReminders += count;
    }

    public void AddBroadcast(int count)
    {
        _stats.BroadcastMessages += count;
    }

    public NotificationStatsDto GetStats()
    {
        return _stats;
    }

    public List<AttendanceTrendDto> GetAttendanceTrend()
    {
        return _trend;
    }
}