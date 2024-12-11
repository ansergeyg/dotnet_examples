using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfFileGenerator;

namespace RazorPageClient.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IWebHostEnvironment _env;

    [BindProperty]
    public Employee Worker {get; set;} = new Employee();

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public void OnGet()
    {

    }
    
    public IActionResult OnPost()
    {
        // DebugModelState();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // You can map your page entities to your database entities
        var newEmployee = new Employee
        {
            FirstName = Worker.FirstName,
            LastName = Worker.LastName,
            Age = Worker.Age,
            Description = Worker.Description,
            Status = Worker.Status,
            BirthDate = Worker.BirthDate,
        };


        List<string> myData = new List<string>() 
        {Worker.FirstName, Worker.LastName, Worker.Description, Worker.Age.ToString(), Worker.BirthDate.ToShortDateString()};

        string filePath = "my_test_pdf.pdf";

        //Generate pdf
        //TODO: First make it syncronous operation. then refactor to async
        PdfFileBuilder pdfCreator = new PdfFileBuilder(filePath, myData);
        pdfCreator.Generate();

        /*
            There are two way to locate your generated file:

            1) Use directory absolute path to locate our generated file.
            2) If you publish the website then you need to use virtual path,
                because it works only in wwwroot folder.
                The ~ (tilde) prefix only works for static files or paths registered with a file provider (e.g., files in wwwroot).
                Example: ~/my_test_pdf.pdf
        */

        // Locate file using direct absolute path:
        // var absPath = Path.Combine(Directory.GetCurrentDirectory(), "my_test_pdf.pdf");
        // var fileStream = new FileStream(absPath, FileMode.Open, FileAccess.Read);

        // Locate file using IWebHost path:
        var dynPath = Path.Combine(_env.ContentRootPath, "my_test_pdf.pdf");
        var fileStream = new FileStream(dynPath, FileMode.Open, FileAccess.Read);

        return File(fileStream, "application/pdf");
    }

    public void DebugModelState()
    {
        foreach (var key in ModelState.Keys)
        {
            var errors = ModelState[key].Errors;
            foreach (var error in errors)
            {
                Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
            }
        }
    }
}
