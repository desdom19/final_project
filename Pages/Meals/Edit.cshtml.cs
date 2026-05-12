using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using final_project.Models;

namespace final_project.Pages_Meals
{
    public class EditModel : PageModel
    {
        private readonly final_project.Models.AppDbContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(final_project.Models.AppDbContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Meal Meal { get; set; } = default!;

        public List<Ingredient> Ingredients {get;set;} = default!;


        // Update

        [BindProperty]
        public int IngredientIDToUpdate {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal =  await _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefaultAsync(m => m.MealID == id);

            Ingredients = _context.Ingredients.ToList();


            if (meal == null)
            {
                return NotFound();
            }
            Meal = meal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedIngredients)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mealToUpdate = await _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefaultAsync(m => m.MealID == Meal.MealID);
            if (mealToUpdate != null)
            {
                mealToUpdate.MealName = Meal.MealName;
                mealToUpdate.TimeCategory = Meal.TimeCategory;
                mealToUpdate.PreparationTime = Meal.PreparationTime;
               
                
            }

           // _context.Attach(Meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(Meal.MealID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MealExists(int id)
        {
            return _context.Meals.Any(e => e.MealID == id);
        }

         public IActionResult OnPostUpdateIngredient(int? id, decimal newQuantity)
        {
            _logger.LogWarning($"Update Ingredient: MealID {id}, UPDATE ingredient {IngredientIDToUpdate}");

            if (id == null)
            {
                return NotFound();
            }

            var meal = _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefault(m => m.MealID == id);

            if (meal == null)
            {
                return NotFound();
            }
            else
            {
                Meal = meal;
            }

            var ingredientToUpdate = _context.MealIngredients.Find(IngredientIDToUpdate, id);

            if (ingredientToUpdate != null)
            {
                ingredientToUpdate.Quantity = newQuantity;

                if (newQuantity <= 0)
                {
                    _logger.LogWarning("Invalid quantity");
                    return Page();
                }
                else
                {
                _context.SaveChanges();
                }
            }
            else
            {
                _logger.LogWarning("No found ingredient to update");
            }
            return Page();
        }



        
    }
}



