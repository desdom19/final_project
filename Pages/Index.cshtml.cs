using System.ComponentModel.DataAnnotations;
using final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace final_project.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    [Display(Name = "Meal Name")]
    [StringLength(60, MinimumLength = 10)]

    public string IdeaName {get;set;} = string.Empty;

    [BindProperty]
    [Display(Name = "Meal Description")]
    [MinLength(10)]
    public string IdeaDescription {get;set;} = string.Empty;

    public List<Meal> Meals {get;set;} = default!;


    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;

        
    }
    
    public void OnGet(int id)
    {
        
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            _logger.LogWarning("OnPost() Invalid Model State. Returning to previous page");
            return Page();
        }
        
        _logger.LogInformation($"OnPost() Valid Model - {IdeaName} {IdeaDescription}");
        return Page();
    }
}
