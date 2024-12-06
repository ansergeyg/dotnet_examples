// Test Excel file generation:
// The file will appear in the ConsoleClient root folder.

using ExcelFileGenerator;
using PdfFileGenerator;

List<string> myData = new List<string>() 
{"You", "can", "put", "any", "data", "here", "Kristina", "stupis"};

// ExcelFileBuilder excelCreator = new ExcelFileBuilder("my_excel_file.xlsx", myData);
// excelCreator.Generate();


PdfFileBuilder pdfCreator = new PdfFileBuilder("my_pdf_file.pdf", myData);
pdfCreator.Generate();
