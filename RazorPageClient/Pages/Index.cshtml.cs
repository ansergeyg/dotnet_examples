using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageClient.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    [BindProperty]
    public Employee Worker {get; set;} = new Employee();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    // TODO: WRITE HANLDER TO EXPORT PDF
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var newEmployee = new Employee
        {
            FirstName = Worker.FirstName,
            LastName = Worker.LastName,
            Age = Worker.Age,
            Description = Worker.Description,
            Status = Worker.Status,
            BirthDate = Worker.BirthDate,
        };

        return RedirectToPage("Index");
    }
}
