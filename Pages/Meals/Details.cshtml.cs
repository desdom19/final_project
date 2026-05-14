using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_project.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace final_project.Pages_Meals
{
    public class DetailsModel : PageModel
    {
        private readonly final_project.Models.AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(final_project.Models.AppDbContext context, ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Meal Meal { get; set; } = default!;


        [Display(Name = "Total Calories")]
        public decimal CaloriesTotal {get;set;}
      
        public decimal CostTotal {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefaultAsync(m => m.MealID == id);

            if (meal is not null)
            {
                Meal = meal;

                CaloriesTotal = Meal.MealIngredients?.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCalories) ?? 0;

                CostTotal = Meal.MealIngredients?.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCost) ?? 0;

                return Page();
            }

            return NotFound();
        }

    }

}
