namespace CoachingAutomationExcel.Models;

public class PreviewDto
{
    public string Module { get; set; } = string.Empty;

    public int TotalRecords { get; set; }

    public int ActionableRecords { get; set; }
}