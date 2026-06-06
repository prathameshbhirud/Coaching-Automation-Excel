using CoachingAutomationExcel.Data;
using CoachingAutomationExcel.Entities;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class StatisticsService
{
    private readonly CoachingDbContext _db;

    public StatisticsService(CoachingDbContext db)
    {
        _db = db;
    }

    public void AddAttendance(int count)
    {
        UpdateStat("Attendance", count);
    }

    public void AddFees(int count)
    {
        UpdateStat("Fees", count);
    }

    public void AddExams(int count)
    {
        UpdateStat("Exams", count);
    }

    public void AddBroadcast(int count)
    {
        UpdateStat("Broadcast", count);
    }

    private void UpdateStat(string type, int count)
    {
        var stat = _db.NotificationStatistics.FirstOrDefault(x => x.NotificationType == type);

        if (stat == null)
        {
            stat = new NotificationStatistic
            {
                NotificationType = type,
                Count = 0
            };

            _db.NotificationStatistics.Add(stat);
        }

        stat.Count += count;

        _db.SaveChanges();
    }

    public NotificationStatsDto GetStats()
    {
        return new NotificationStatsDto
        {
            AttendanceMessages = GetCount("Attendance"),

            FeeReminders = GetCount("Fees"),

            ExamReminders = GetCount("Exams"),

            BroadcastMessages = GetCount("Broadcast")
        };
    }

    private int GetCount(string type)
    {
        return _db.NotificationStatistics.FirstOrDefault(x => x.NotificationType == type)?.Count ?? 0;
    }

    public List<AttendanceTrendDto> GetAttendanceTrend()
    {
        return new List<AttendanceTrendDto>
        {
            new() { Date = "Mon", Count = 12 },
            new() { Date = "Tue", Count = 15 },
            new() { Date = "Wed", Count = 8 },
            new() { Date = "Thu", Count = 18 },
            new() { Date = "Fri", Count = 11 }
        };
    }
}