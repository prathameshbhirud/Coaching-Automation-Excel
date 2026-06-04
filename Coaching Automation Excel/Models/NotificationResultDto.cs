namespace CoachingAutomationExcel.Models;

public class NotificationResultDto
{
    public string Module { get; set; } = string.Empty;

    public int Processed { get; set; }

    public int Sent { get; set; }

    public int Failed { get; set; }

    public DateTime ExecutedAt { get; set; }
}