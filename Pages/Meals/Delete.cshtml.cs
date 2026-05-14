using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_project.Models;

namespace final_project.Pages_Meals
{
    public class DeleteModel : PageModel
    {
        private readonly final_project.Models.AppDbContext _context;

        public DeleteModel(final_project.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public decimal CaloriesTotal {get;set;}
      
        public decimal CostTotal {get;set;}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefaultAsync(m => m.MealID == id);

            if (meal == null)
            {
                return NotFound();
            }

            Meal = meal;

            if (Meal.MealIngredients == null)
            {
                CaloriesTotal = 0;
                CostTotal = 0;
            }
            
                CaloriesTotal = Meal.MealIngredients?.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCalories) ?? 0;

                CostTotal = Meal.MealIngredients?.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCost) ?? 0;
                
    

               
                return Page();
                
            }

            
        

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                Meal = meal;
                _context.Meals.Remove(Meal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
