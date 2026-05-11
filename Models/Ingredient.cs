using System.ComponentModel.DataAnnotations;
namespace final_project.Models;

public class Ingredient
{
    public int IngredientID {get;set;} //Primary Key

    // [Required] is omitted for string properties since they are non-nullable by default
    [Display(Name = "Ingredient")]
    [StringLength(60, MinimumLength = 5)]
    public string IngredientName {get;set;} = string.Empty;

    [Display(Name = "Food Category")]
    [StringLength(20, MinimumLength = 5)]
    public string FoodCategory {get;set;} = string.Empty;


    [Display(Name = "Storage Type")]
    public string StorageType {get;set;} = string.Empty;

    [Required]
    [Display(Name = "Expiration (Days)")]
    [Range(1,100)]
    public int ExpirationTime {get;set;}

    [Required]
    [Range(0.01,999.99)]
    [Display(Name = "Calories Per Ingredient")]
    public decimal IngredientCalories {get;set;}

    [Required]
    [Range(0.01,999.99)]
    [Display(Name = "Cost Per Ingredient")]
    public decimal IngredientCost {get;set;}

    [Display(Name = "Unit of Measurement")]
    [StringLength(20, MinimumLength = 5)]
    public string UnitMeasurement {get;set;} = string.Empty;
    

    public List<MealIngredient>? MealIngredients {get;set;} = default!; // Navigation property
}

public class MealIngredient
{
    public int IngredientID {get;set;} //Composite Primary Key, Foreign Key
    public int MealID {get;set;} //Composite Primary Key, Foreign Key
    public Meal Meal {get;set;} = default!; // Navigation Property
    public Ingredient Ingredient {get;set;} = default!; // Navigation Property
    [Range(0.01,999.99)]
    public decimal Quantity {get;set;} 
}