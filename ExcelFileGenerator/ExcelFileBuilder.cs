using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelFileGenerator;

public class ExcelFileBuilder(string filePath, List<string> input)
{
    public string filePath { get; set; } = filePath;
    public List<string> Input { get; set; } = input;

    public void Generate()
    {
        using (SpreadsheetDocument doc = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
        {
            WorkbookPart bookPart = doc.AddWorkbookPart();
            bookPart.Workbook = new Workbook();
            WorksheetPart sheetPart = bookPart.AddNewPart<WorksheetPart>();
            Sheets sheets = doc.WorkbookPart.Workbook.AppendChild(new Sheets());

            // Set sheet metadata
            Sheet sheet = new Sheet()
            {
                Id = doc.WorkbookPart.GetIdOfPart(sheetPart),
                SheetId = 1,
                Name = "MySheet 1",
            };
            sheets.Append(sheet);
            
            // Set actual sheet data
            Row newRow = new Row();
            foreach (string cellData in input)
            {
                Cell newCell = new Cell()
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(cellData)
                };

                newRow.Append(newCell);
            }

            SheetData newSheetData = new SheetData();
            sheetPart.Worksheet = new Worksheet(newSheetData);
            newSheetData.Append(newRow);

            // Create file
            bookPart.Workbook.Save();
        }

    } 
}