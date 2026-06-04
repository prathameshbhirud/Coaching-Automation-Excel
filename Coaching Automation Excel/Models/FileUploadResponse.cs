namespace CoachingAutomationExcel.Models;

public class FileUploadResponse
{
    public bool Success { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}