using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using final_project.Models;
using System.ComponentModel;

namespace final_project.Pages_Meals
{
    public class IndexModel : PageModel
    {
        private readonly final_project.Models.AppDbContext _context;

        public IndexModel(final_project.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Meal> Meal { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} = 10;
        public int TotalPages {get;set;} 

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get;set;} = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch {get;set;} = string.Empty;

        public decimal CaloriesTotal {get;set;}
      
        public decimal CostTotal {get;set;}

        

        public async Task OnGetAsync()
        {

          var query = _context.Meals.Include(m => m.MealIngredients!).ThenInclude(mi => mi.Ingredient).Select(m => m);

            // Search
            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(m => m.MealName.ToUpper().Contains(CurrentSearch.ToUpper()));
            }
            // Sort
            switch (CurrentSort)
            {
                case "time_asc":
                    query = query.OrderBy(m => m.TimeCategory);
                    break;
                case "time_desc":
                    query = query.OrderByDescending(m => m.TimeCategory);
                    break;

                    case "minutes_asc":
                        query = query.OrderBy(m => m.PreparationTime);
                    break;
                    case "minutes_desc":
                        query = query.OrderByDescending(m => m.PreparationTime);
                    break;

                    case "calories_asc":
                        query = query.OrderBy(m => m.MealIngredients!.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCalories));
                    break;
                    case "calories_desc":
                        query = query.OrderByDescending(m => m.MealIngredients!.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCalories));
                    break;

                    case "cost_asc":
                        query = query.OrderBy(m => m.MealIngredients!.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCost));
                    break;
                    case "cost_desc":
                        query = query.OrderByDescending(m => m.MealIngredients!.Sum(mi => mi.Quantity * mi.Ingredient.IngredientCost));
                    break;


            



            }

            //Pagination

            TotalPages = (int)Math.Ceiling(query.Count()/(double)PageSize);
            Meal = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
