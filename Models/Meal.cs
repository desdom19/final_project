using System.ComponentModel.DataAnnotations;

namespace final_project.Models;

public class Meal
{
    public int MealID {get;set;} //Primary Key

    // [Required] is omitted for string properties since they are non-nullable by default
    [Display(Name = "Meal")]
    [StringLength(60, MinimumLength = 10)]
    public string MealName {get;set;} = string.Empty;


    [Display(Name = "Time of Day")]
    public string TimeCategory {get;set;} = string.Empty;

    [Required]
    [Display(Name = "Preparation Time (Minutes)")]
    [Range(1,90)]
    public int PreparationTime {get;set;}

    [Required]
    [Range(0.01,1200)]
    [Display(Name = "Total Calories")]
    public decimal TotalCalories {get;set;}

    [Required]
    [Range(0.01,500)]
    [Display(Name = "Total Cost")]
    public decimal TotalCost {get;set;}

    [Display(Name = "Meal Ingredients")]
    public List<MealIngredient>? MealIngredients {get;set;} = default!; // Navigation property
}