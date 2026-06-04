namespace CoachingAutomationExcel.Models;

public class UploadAttendanceResponse
{
    public bool Success { get; set; }

    public string Message { get; set; } = "";

    public PreviewDto Preview { get; set; } = new();
}