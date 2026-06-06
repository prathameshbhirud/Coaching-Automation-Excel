using ClosedXML.Excel;
using CoachingAutomationExcel.Models;

namespace CoachingAutomationExcel.Services;

public class ExportService
{
    public byte[] ExportAttendance(IEnumerable<Student> students)
    {
        using var workbook = new XLWorkbook();

        var sheet = workbook.Worksheets.Add("Attendance");

        sheet.Cell(1, 1).Value = "Student Name";
        sheet.Cell(1, 2).Value = "Phone";
        sheet.Cell(1, 3).Value = "Attendance";

        int row = 2;

        foreach(var student in students)
        {
            sheet.Cell(row, 1).Value = student.StudentName;
            sheet.Cell(row, 2).Value = student.ParentPhone;
            sheet.Cell(row, 3).Value = student.Attendance;
            row++;
        }

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] ExportFees(IEnumerable<Student> students)
    {
        using var workbook = new XLWorkbook();

        var sheet = workbook.Worksheets.Add("Fees");

        sheet.Cell(1, 1).Value = "Student Name";
        sheet.Cell(1, 2).Value = "Phone";
        sheet.Cell(1, 3).Value = "Fees Due";

        int row = 2;

        foreach (var student in students)
        {
            sheet.Cell(row, 1).Value = student.StudentName;
            sheet.Cell(row, 2).Value = student.ParentPhone;
            sheet.Cell(row, 3).Value = student.FeesDue;
            row++;
        }

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] ExportExams(IEnumerable<Student> students)
    {
        using var workbook = new XLWorkbook();

        var sheet = workbook.Worksheets.Add("Exams");

        sheet.Cell(1, 1).Value = "Student Name";
        sheet.Cell(1, 2).Value = "Phone";
        sheet.Cell(1, 3).Value = "Exam Name";
        sheet.Cell(1, 4).Value = "Exam Date";

        int row = 2;

        foreach (var student in students)
        {
            sheet.Cell(row, 1).Value = student.StudentName;
            sheet.Cell(row, 2).Value = student.ParentPhone;
            sheet.Cell(row, 3).Value = student.ExamName;
            sheet.Cell(row, 4).Value = student.ExamDate?.ToString("dd-MMM-yyyy");
            row++;
        }

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }

    public byte[] ExportBroadcast(IEnumerable<BroadcastMessage> broadcasts)
    {
        using var workbook = new XLWorkbook();

        var sheet = workbook.Worksheets.Add("Broadcast");

        sheet.Cell(1, 1).Value = "Message";

        int row = 2;

        foreach (var item in broadcasts)
        {
            sheet.Cell(row, 1).Value = item.Message;
            row++;
        }

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        return stream.ToArray();
    }
}