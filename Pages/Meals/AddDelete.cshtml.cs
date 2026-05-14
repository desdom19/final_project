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
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System.Numerics;

namespace final_project.Pages_Meals
{
    public class AddDeleteModel : PageModel
    {
        
        private readonly final_project.Models.AppDbContext _context;
        private readonly ILogger<AddDeleteModel> _logger;

        public AddDeleteModel(final_project.Models.AppDbContext context, ILogger<AddDeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

         public Meal Meal { get; set; } = default!;

        
        [BindProperty]
        [Display(Name = "Add Ingredient")]
        [Required(ErrorMessage = "Must select at least one ingredient")]
        public int IngredientIDToAdd {get;set;}


        [BindProperty]
        [Range(0.01,999.99)]
        [Required(ErrorMessage = "Invalid Quantity")]
        public decimal AddedIngredientQuantity {get;set;}

       
        [BindProperty]
        public int IngredientIDToDelete {get;set;}
        public SelectList IngredientsDropDown {get;set;} = default!;

        public List<Ingredient>? AllIngredients {get;set;}

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

                IngredientsDropDown = new SelectList(_context.Ingredients.ToList(),"IngredientID", "IngredientName" );

                AllIngredients = await _context.Ingredients.ToListAsync();

                return Page();
            }

            return NotFound();
        }

        //Database addition 
          public IActionResult OnPostAddIngredient(int? id)
        {
            _logger.LogWarning($"Add Ingredient: MealID {id}, ADD ingredient {IngredientIDToAdd}");


            if(id == null)
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

            IngredientsDropDown = new SelectList(_context.Ingredients.ToList(), "IngredientID", "IngredientName");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Model State is INVALID");
                return Page();
            }

            if (!_context.MealIngredients.Any(mi => mi.IngredientID == IngredientIDToAdd && mi.MealID == id))
            {
                MealIngredient ingredientToAdd = new MealIngredient {MealID = id.Value, IngredientID = IngredientIDToAdd, Quantity = AddedIngredientQuantity};
                if (AddedIngredientQuantity <= 0)
                {
                    _logger.LogWarning("Invalid quantity");
                    return Page();
                }
                else
                {
                _context.Add(ingredientToAdd);
                _context.SaveChanges();

                }
  
            } 
            else
            {
                _logger.LogWarning("Ingredient already utilized in meal");
                
            }

             return RedirectToPage(new {id = id});
        }

        //Database removal 

        public IActionResult OnPostRemoveIngredient(int? id)
        {
            _logger.LogWarning($"Remove Ingredient: MealID {id}, REMOVE ingredient {IngredientIDToDelete}");

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
            IngredientsDropDown = new SelectList(_context.Ingredients.ToList(), "IngredientID", "IngredientName");

            var ingredientToDrop = _context.MealIngredients.Find(IngredientIDToDelete, id);

            if (ingredientToDrop != null)
            {
                _context.Remove(ingredientToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Ingredient NOT utilized in meal");
            }

            return RedirectToPage(new {id = id});
        }

        //Allows user exit if ingredient validation is satisfied

        public IActionResult OnPostDoneCreating(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).FirstOrDefault(m => m.MealID == id);

            if (meal == null)
            {
                return NotFound();
            }

            if (meal.MealIngredients == null || meal.MealIngredients.Count == 0)
            {
                _logger.LogWarning("Meal must have at least one ingredient");

                Meal = meal;
           

            IngredientsDropDown = new SelectList(_context.Ingredients.ToList(), "IngredientID", "IngredientName");

            AllIngredients = _context.Ingredients.ToList();

            return Page();
            }

            return RedirectToPage("./Index");
        }

        

    }

}






