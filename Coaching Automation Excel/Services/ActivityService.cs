using CoachingAutomationExcel.Models;
using CoachingAutomationExcel.Data;
using CoachingAutomationExcel.Entities;

namespace CoachingAutomationExcel.Services;

public class ActivityService
{
    private readonly CoachingDbContext _db;

    public ActivityService(CoachingDbContext db)
    {
        _db = db;
    }

    public void Add(string message)
    {
        _db.ActivityLogs.Add(new ActivityLog
        {
            Message = message,
            Timestamp = DateTime.Now
        });

        _db.SaveChanges();
    }

    public List<ActivityLogDto> GetRecent()
    {
        return _db.ActivityLogs
            .OrderByDescending(x => x.Timestamp)
            .Take(20)
            .Select(x => new ActivityLogDto
            {
                Message = x.Message,
                Timestamp = x.Timestamp
            })
            .ToList();
    }
}