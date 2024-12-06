using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PdfFileGenerator;

public class PdfFileBuilder(string filePath, List<string> input)
{
    public string filePath { get; set; } = filePath;
    public List<string> Input {get; set; } = input;

    public void Generate()
    {
        QuestPDF.Settings.License = LicenseType.Community;

        Document.Create(container => 
        {
            container.Page(page => 
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.Background(Colors.White);
                page.DefaultTextStyle(font => font.FontSize(20));

                page.Header()
                    .Text("Hello PDF!") // You can add your text here
                    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(col =>
                    {
                        col.Spacing(20);
                        col.Item().Text(String.Join(" ", input));  // You can add your text here
                        col.Item().Image(Placeholders.Image(200, 100));
                    });
                
                page.Footer()
                    .AlignCenter()
                    .Text(foo => 
                    {
                        foo.Span("Page ");  // You can add your text here
                        foo.CurrentPageNumber();
                    });
            }); 
        })
        .GeneratePdf(filePath);
    }
}


