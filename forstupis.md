# Excel File generation

link to get openxml: https://www.nuget.org/packages/documentformat.openxml

tutorial: https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk


Словарь:

Spreadsheet - электронная таблица

Workbook - рабочая книга

Worksheet - рабочий лист

sheet - лист

Row - строка

Cell - ячейка

Column - столбец

Как работает excel?

Excel - это электронная таблица (spreadsheet) данных.

Почему таблица? Потому что она состоит из строк (Rows) и колонок (Columns). А они, в свою очередь, образуют ячейки (Cells).

Любой excel файл представляет собой, как бы, электронную книгу (Workbook), которая состоит из листов (Worksheet), которые состоят из строк (Rows) и 

столбцов (Columns), которые образуют ячейки (Cells). Ячейка - это неделимый наименьший объект, котороый хранит данные.

Как создается excel file?

Создаем основной объект spreadsheet. Затем внутри него создаем workbook, а внутри workbook создаем worksheet. Ну и в самом конце надо создать ячейки (cells).


Explanation how excel works:

1. Workbook

Definition: A file created in Excel. It acts as a container for all the data and functionality.

2. Worksheet (Sheet)

Definition: A single tab/page within a workbook.

3. Cells

Definition: The smallest unit in a worksheet where data is entered.

4. Rows

Definition: Horizontal lines of cells in a worksheet.

5. Columns

Definition: Vertical lines of cells in a worksheet.

6. Range

7. Charts

8. Formulas and Functions

Hierarchy of Creating an Excel File:

Create a Workbook: Start by opening a new or existing workbook.

Add Worksheets: Add as many sheets as needed to organize your data.

Enter Data in Cells: Populate cells with text, numbers, or formulas.

Organize Data: Use rows and columns for structure.

Create Ranges: Select specific ranges for calculations or operations.


# Pdf File generation

Link to the library: https://www.nuget.org/packages/QuestPDF

tutorial: https://www.questpdf.com/getting-started


Command to install a tool to preview generated pdf

dotnet tool install QuestPDF.Previewer --global

dotnet watch - hot reload while building

if you use just GeneratePDF() method it will generate pdf in you repository folder. Look it up there.

