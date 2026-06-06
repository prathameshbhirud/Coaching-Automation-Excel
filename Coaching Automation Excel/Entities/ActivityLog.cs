namespace CoachingAutomationExcel.Entities;

public class ActivityLog
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }
}