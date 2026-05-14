using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using final_project.Models;

namespace final_project.Pages_Meals
{
    public class CreateModel : PageModel
    {
        private readonly final_project.Models.AppDbContext _context;
        private readonly ILogger<CreateModel> _logger;

         public CreateModel(final_project.Models.AppDbContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        [BindProperty]
        public Meal Meal { get; set; } = default!;

        


         public IActionResult OnGet()
        {

            
            return Page();
        }

        

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                
                return Page();
            }

            _context.Meals.Add(Meal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddDelete", new {id = Meal.MealID});

 
        }

           
        }
    }

