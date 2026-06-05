namespace CoachingAutomationExcel.Models;

public class DashboardSummaryDto
{
    public int TotalStudents { get; set; }

    public int AttendanceToday { get; set; }

    public int PendingFees { get; set; }

    public int UpcomingExams { get; set; }

    public bool IsDataAvailable { get; set; }
}