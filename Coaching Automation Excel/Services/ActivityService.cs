using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class ActivityService
{
    private static readonly List<ActivityLogDto> _logs = new();

    public void Add(string message)
    {
        _logs.Insert(0, new ActivityLogDto
        {
            Message = message,
            Timestamp = DateTime.Now
        });

        if (_logs.Count > 50)
            _logs.RemoveAt(_logs.Count - 1);
    }

    public List<ActivityLogDto> GetRecent()
    {
        return _logs.Take(10).ToList();
    }
}