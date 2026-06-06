using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CoachingAutomationExcel.Services;

public class PdfExportService
{
    public byte[] GeneratePdf(string title, List<string> headers, List<List<string>> rows)
    {
        return Document.Create(container =>{
            container.Page(page =>{
                page.Margin(30);
                page.Header()
                    .Text(title)
                    .FontSize(20)
                    .Bold();

                page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in headers)
                            {
                                columns.RelativeColumn();
                            }
                        });

                        table.Header(header =>
                        {
                            foreach (var column in headers)
                            {
                                header.Cell()
                                    .Border(1)
                                    .Padding(5)
                                    .Text(column)
                                    .Bold();
                            }
                        });

                        foreach (var row in rows)
                        {
                            foreach (var value in row)
                            {
                                table.Cell()
                                    .Border(1)
                                    .Padding(5)
                                    .Text(value);
                            }
                        }
                    });

                page.Footer().AlignCenter().Text($"Generated on {DateTime.Now:dd-MMM-yyyy HH:mm}");
            });
        })
        .GeneratePdf();
    }
}