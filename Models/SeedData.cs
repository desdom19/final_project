using Microsoft.EntityFrameworkCore;
namespace final_project.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Meals.Any())
        {
            return;
        }


        List<Meal> meals = new List<Meal>
        {
            new Meal { MealName = "Scrambled Eggs with Avocado", TimeCategory = "Breakfast", PreparationTime = 10},
            new Meal { MealName = "Oatmeal with Berries and Honey", TimeCategory = "Breakfast", PreparationTime = 5},
            new Meal { MealName = "Greek Yogurt Parfait", TimeCategory = "Breakfast", PreparationTime = 5},
            new Meal { MealName = "Peanut Butter Banana Toast", TimeCategory = "Breakfast", PreparationTime = 5},
            new Meal { MealName = "Breakfast Burrito with Salsa", TimeCategory = "Breakfast", PreparationTime = 15},
            new Meal { MealName = "Pancakes with Maple Syrup", TimeCategory = "Breakfast", PreparationTime = 20},
            new Meal { MealName = "Fruit and Spinach Smoothie", TimeCategory = "Breakfast", PreparationTime = 5},
            new Meal { MealName = "Belgian Waffles with Cream", TimeCategory = "Breakfast", PreparationTime = 25},
            new Meal { MealName = "Avocado Toast with Poached Egg", TimeCategory = "Breakfast", PreparationTime = 10},
            new Meal { MealName = "Egg Muffins with Spinach", TimeCategory = "Breakfast", PreparationTime = 30},
            new Meal { MealName = "Grilled Chicken Caesar Salad", TimeCategory = "Lunch", PreparationTime = 15},
            new Meal { MealName = "Turkey and Swiss Cheese Wrap", TimeCategory = "Lunch", PreparationTime = 10},
            new Meal { MealName = "Quinoa and Black Bean Bowl", TimeCategory = "Lunch", PreparationTime = 20},
            new Meal { MealName = "Tomato Basil Soup", TimeCategory = "Lunch", PreparationTime = 25},
            new Meal { MealName = "Tuna Salad Sandwich", TimeCategory = "Lunch", PreparationTime = 10},
            new Meal { MealName = "Caprese Salad with Balsamic", TimeCategory = "Lunch", PreparationTime = 10},
            new Meal { MealName = "Chicken Noodle Soup", TimeCategory = "Lunch", PreparationTime = 35},
            new Meal { MealName = "Hummus and Veggie Pita", TimeCategory = "Lunch", PreparationTime = 10},
            new Meal { MealName = "BBQ Pulled Pork Slider", TimeCategory = "Lunch", PreparationTime = 15},
            new Meal { MealName = "Cobb Salad with Ranch", TimeCategory = "Lunch", PreparationTime = 15},
            new Meal { MealName = "Spaghetti Bolognese", TimeCategory = "Dinner", PreparationTime = 40},
            new Meal { MealName = "Baked Salmon with Asparagus", TimeCategory = "Dinner", PreparationTime = 25},
            new Meal { MealName = "Beef Stir-Fry with Broccoli", TimeCategory = "Dinner", PreparationTime = 20},
            new Meal { MealName = "Chicken Parmesan with Pasta", TimeCategory = "Dinner", PreparationTime = 45},
            new Meal { MealName = "Tacos with Ground Beef", TimeCategory = "Dinner", PreparationTime = 20},
            new Meal { MealName = "Margherita Pizza", TimeCategory = "Dinner", PreparationTime = 35},
            new Meal { MealName = "Pork Chops with Applesauce", TimeCategory = "Dinner", PreparationTime = 30},
            new Meal { MealName = "Lentil Curry with Rice", TimeCategory = "Dinner", PreparationTime = 40},
            new Meal { MealName = "Shrimp Scampi over Linguine", TimeCategory = "Dinner", PreparationTime = 20},
            new Meal { MealName = "Grilled Steak with Garlic Butter", TimeCategory = "Dinner", PreparationTime = 20}




        };
        context.AddRange(meals);
        context.SaveChanges();


        List<Ingredient> ingredients = new List<Ingredient>
        {
            new Ingredient { IngredientName = "Eggs", FoodCategory = "Dairy/Eggs", StorageType = "Fridge", ExpirationTime = 21, IngredientCalories = 70.00m, IngredientCost = 0.25m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Avocado", FoodCategory = "Produce", StorageType = "Pantry", ExpirationTime = 4, IngredientCalories = 240.00m, IngredientCost = 1.50m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Rolled Oats", FoodCategory = "Grains", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 300.00m, IngredientCost = 0.40m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Mixed Berries", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 5, IngredientCalories = 80.00m, IngredientCost = 1.20m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Honey", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 730, IngredientCalories = 60.00m, IngredientCost = 0.15m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Greek Yogurt", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 14, IngredientCalories = 130.00m, IngredientCost = 1.10m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Granola", FoodCategory = "Grains", StorageType = "Pantry", ExpirationTime = 180, IngredientCalories = 450.00m, IngredientCost = 1.15m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Whole Wheat Bread", FoodCategory = "Bakery", StorageType = "Pantry", ExpirationTime = 7, IngredientCalories = 70.00m, IngredientCost = 0.15m, UnitMeasurement = "slice" },
            new Ingredient { IngredientName = "Peanut Butter", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 95.00m, IngredientCost = 0.12m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Banana", FoodCategory = "Produce", StorageType = "Pantry", ExpirationTime = 5, IngredientCalories = 105.00m, IngredientCost = 0.25m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Flour Tortilla", FoodCategory = "Bakery", StorageType = "Pantry", ExpirationTime = 14, IngredientCalories = 150.00m, IngredientCost = 0.35m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Salsa", FoodCategory = "Pantry", StorageType = "Fridge", ExpirationTime = 30, IngredientCalories = 10.00m, IngredientCost = 0.10m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Pancake Mix", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 300.00m, IngredientCost = 0.40m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Maple Syrup", FoodCategory = "Pantry", StorageType = "Fridge", ExpirationTime = 365, IngredientCalories = 52.00m, IngredientCost = 0.35m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Fresh Spinach", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 7, IngredientCalories = 10.00m, IngredientCost = 0.55m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Milk", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 10, IngredientCalories = 120.00m, IngredientCost = 0.40m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Frozen Waffles", FoodCategory = "Bakery", StorageType = "Freezer", ExpirationTime = 90, IngredientCalories = 90.00m, IngredientCost = 0.40m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Heavy Cream", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 30, IngredientCalories = 50.00m, IngredientCost = 0.15m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Chicken Breast", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 3, IngredientCalories = 250.00m, IngredientCost = 1.40m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Romaine Lettuce", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 7, IngredientCalories = 15.00m, IngredientCost = 0.60m, UnitMeasurement = "head" },
            new Ingredient { IngredientName = "Caesar Dressing", FoodCategory = "Pantry", StorageType = "Fridge", ExpirationTime = 60, IngredientCalories = 80.00m, IngredientCost = 0.22m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Deli Turkey", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 5, IngredientCalories = 30.00m, IngredientCost = 0.28m, UnitMeasurement = "slice" },
            new Ingredient { IngredientName = "Swiss Cheese", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 21, IngredientCalories = 100.00m, IngredientCost = 0.40m, UnitMeasurement = "slice" },
            new Ingredient { IngredientName = "Quinoa", FoodCategory = "Grains", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 160.00m, IngredientCost = 0.90m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Black Beans", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 240.00m, IngredientCost = 0.70m, UnitMeasurement = "can" },
            new Ingredient { IngredientName = "Canned Tomatoes", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 730, IngredientCalories = 70.00m, IngredientCost = 0.50m, UnitMeasurement = "can" },
            new Ingredient { IngredientName = "Fresh Basil", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 5, IngredientCalories = 5.00m, IngredientCost = 0.40m, UnitMeasurement = "oz" },
            new Ingredient { IngredientName = "Pizza Dough", FoodCategory = "Grains", StorageType = "Fridge", ExpirationTime = 7, IngredientCalories = 220.00m, IngredientCost = 1.10m, UnitMeasurement = "ball" },
            new Ingredient { IngredientName = "Spaghetti Noodles", FoodCategory = "Grains", StorageType = "Pantry", ExpirationTime = 730, IngredientCalories = 210.00m, IngredientCost = 0.45m, UnitMeasurement = "serving" },
            new Ingredient { IngredientName = "Applesauce", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 180, IngredientCalories = 90.00m, IngredientCost = 0.40m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Fresh Mozzarella", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 14, IngredientCalories = 250.00m, IngredientCost = 1.65m, UnitMeasurement = "oz" },
            new Ingredient { IngredientName = "Ground Beef", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 3, IngredientCalories = 340.00m, IngredientCost = 2.25m, UnitMeasurement = "lb" },
            new Ingredient { IngredientName = "Sirloin Steak", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 3, IngredientCalories = 310.00m, IngredientCost = 3.75m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Pork Chops", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 4, IngredientCalories = 240.00m, IngredientCost = 1.95m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Salmon Fillet", FoodCategory = "Seafood", StorageType = "Fridge", ExpirationTime = 3, IngredientCalories = 280.00m, IngredientCost = 3.25m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Raw Shrimp", FoodCategory = "Seafood", StorageType = "Freezer", ExpirationTime = 90, IngredientCalories = 120.00m, IngredientCost = 2.80m, UnitMeasurement = "serving" },
            new Ingredient { IngredientName = "Canned Tuna", FoodCategory = "Seafood", StorageType = "Pantry", ExpirationTime = 1095, IngredientCalories = 130.00m, IngredientCost = 1.50m, UnitMeasurement = "can" },
            new Ingredient { IngredientName = "Mayonnaise", FoodCategory = "Pantry", StorageType = "Fridge", ExpirationTime = 90, IngredientCalories = 100.00m, IngredientCost = 0.15m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Garlic Butter", FoodCategory = "Dairy", StorageType = "Fridge", ExpirationTime = 30, IngredientCalories = 100.00m, IngredientCost = 0.35m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Baking Flour", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 450.00m, IngredientCost = 0.60m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Asparagus", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 5, IngredientCalories = 25.00m, IngredientCost = 0.90m, UnitMeasurement = "bunch" },
            new Ingredient { IngredientName = "Broccoli", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 7, IngredientCalories = 30.00m, IngredientCost = 0.65m, UnitMeasurement = "head" },
            new Ingredient { IngredientName = "Pizza Sauce", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 60.00m, IngredientCost = 0.60m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Hummus", FoodCategory = "Deli", StorageType = "Fridge", ExpirationTime = 10, IngredientCalories = 70.00m, IngredientCost = 0.50m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Pita Bread", FoodCategory = "Bakery", StorageType = "Pantry", ExpirationTime = 7, IngredientCalories = 165.00m, IngredientCost = 0.40m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Olive Oil", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 730, IngredientCalories = 120.00m, IngredientCost = 0.20m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Curry Paste", FoodCategory = "Pantry", StorageType = "Pantry", ExpirationTime = 365, IngredientCalories = 45.00m, IngredientCost = 0.55m, UnitMeasurement = "tbsp" },
            new Ingredient { IngredientName = "Jasmine Rice", FoodCategory = "Grains", StorageType = "Pantry", ExpirationTime = 730, IngredientCalories = 160.00m, IngredientCost = 0.25m, UnitMeasurement = "cup" },
            new Ingredient { IngredientName = "Bell Peppers", FoodCategory = "Produce", StorageType = "Fridge", ExpirationTime = 7, IngredientCalories = 30.00m, IngredientCost = 0.70m, UnitMeasurement = "piece" },
            new Ingredient { IngredientName = "Pulled Pork", FoodCategory = "Meat", StorageType = "Fridge", ExpirationTime = 4, IngredientCalories = 220.00m, IngredientCost = 1.70m, UnitMeasurement = "lb" }



        };
        context.AddRange(ingredients);
        context.SaveChanges();


        List<MealIngredient> mealIngredients = new List<MealIngredient>
        {   
            new MealIngredient { MealID = 1, IngredientID = 1, Quantity = 2.0m },
            new MealIngredient { MealID = 1, IngredientID = 2, Quantity = 0.5m },
            new MealIngredient { MealID = 1, IngredientID = 46, Quantity = 1.0m },
            new MealIngredient { MealID = 2, IngredientID = 3, Quantity = 1.0m },
            new MealIngredient { MealID = 2, IngredientID = 4, Quantity = 0.5m },
            new MealIngredient { MealID = 2, IngredientID = 5, Quantity = 1.0m },
            new MealIngredient { MealID = 3, IngredientID = 4, Quantity = 0.5m },
            new MealIngredient { MealID = 3, IngredientID = 6, Quantity = 1.0m },
            new MealIngredient { MealID = 3, IngredientID = 7, Quantity = 0.3m },
            new MealIngredient { MealID = 4, IngredientID = 8, Quantity = 2.0m },
            new MealIngredient { MealID = 4, IngredientID = 9, Quantity = 2.0m },
            new MealIngredient { MealID = 4, IngredientID = 10, Quantity = 1.0m },
            new MealIngredient { MealID = 5, IngredientID = 1, Quantity = 2.0m },
            new MealIngredient { MealID = 5, IngredientID = 11, Quantity = 1.0m },
            new MealIngredient { MealID = 5, IngredientID = 12, Quantity = 2.0m },
            new MealIngredient { MealID = 5, IngredientID = 46, Quantity = 0.5m },
            new MealIngredient { MealID = 6, IngredientID = 13, Quantity = 1.0m },
            new MealIngredient { MealID = 6, IngredientID = 14, Quantity = 2.0m },
            new MealIngredient { MealID = 6, IngredientID = 16, Quantity = 0.5m },
            new MealIngredient { MealID = 7, IngredientID = 10, Quantity = 1.0m },
            new MealIngredient { MealID = 7, IngredientID = 15, Quantity = 1.0m },
            new MealIngredient { MealID = 7, IngredientID = 16, Quantity = 1.0m },
            new MealIngredient { MealID = 8, IngredientID = 17, Quantity = 2.0m },
            new MealIngredient { MealID = 8, IngredientID = 18, Quantity = 2.0m },
            new MealIngredient { MealID = 8, IngredientID = 5, Quantity = 1.0m },
            new MealIngredient { MealID = 9, IngredientID = 1, Quantity = 1.0m },
            new MealIngredient { MealID = 9, IngredientID = 2, Quantity = 0.5m },
            new MealIngredient { MealID = 9, IngredientID = 8, Quantity = 1.0m },
            new MealIngredient { MealID = 10, IngredientID = 1, Quantity = 3.0m },
            new MealIngredient { MealID = 10, IngredientID = 40, Quantity = 0.5m },
            new MealIngredient { MealID = 10, IngredientID = 15, Quantity = 1.0m },
            new MealIngredient { MealID = 10, IngredientID = 16, Quantity = 0.2m },
            new MealIngredient { MealID = 11, IngredientID = 19, Quantity = 1.0m },
            new MealIngredient { MealID = 11, IngredientID = 20, Quantity = 0.2m },
            new MealIngredient { MealID = 11, IngredientID = 21, Quantity = 2.0m },
            new MealIngredient { MealID = 12, IngredientID = 11, Quantity = 1.0m },
            new MealIngredient { MealID = 12, IngredientID = 22, Quantity = 3.0m },
            new MealIngredient { MealID = 12, IngredientID = 23, Quantity = 1.0m },
            new MealIngredient { MealID = 13, IngredientID = 24, Quantity = 1.0m },
            new MealIngredient { MealID = 13, IngredientID = 25, Quantity = 0.5m },
            new MealIngredient { MealID = 13, IngredientID = 49, Quantity = 0.5m },
            new MealIngredient { MealID = 14, IngredientID = 26, Quantity = 1.5m },
            new MealIngredient { MealID = 14, IngredientID = 27, Quantity = 0.5m },
            new MealIngredient { MealID = 14, IngredientID = 18, Quantity = 0.3m },
            new MealIngredient { MealID = 15, IngredientID = 8, Quantity = 2.0m },
            new MealIngredient { MealID = 15, IngredientID = 37, Quantity = 1.0m },
            new MealIngredient { MealID = 15, IngredientID = 38, Quantity = 1.0m },
            new MealIngredient { MealID = 16, IngredientID = 26, Quantity = 1.0m },
            new MealIngredient { MealID = 16, IngredientID = 27, Quantity = 0.5m },
            new MealIngredient { MealID = 16, IngredientID = 31, Quantity = 1.0m },
            new MealIngredient { MealID = 16, IngredientID = 46, Quantity = 0.5m },
            new MealIngredient { MealID = 17, IngredientID = 19, Quantity = 1.0m },
            new MealIngredient { MealID = 17, IngredientID = 29, Quantity = 1.0m },
            new MealIngredient { MealID = 17, IngredientID = 26, Quantity = 0.5m },
            new MealIngredient { MealID = 18, IngredientID = 44, Quantity = 2.0m },
            new MealIngredient { MealID = 18, IngredientID = 45, Quantity = 1.0m },
            new MealIngredient { MealID = 18, IngredientID = 20, Quantity = 0.2m },
            new MealIngredient { MealID = 19, IngredientID = 8, Quantity = 2.0m },
            new MealIngredient { MealID = 19, IngredientID = 50, Quantity = 0.3m },
            new MealIngredient { MealID = 20, IngredientID = 1, Quantity = 1.0m },
            new MealIngredient { MealID = 20, IngredientID = 19, Quantity = 1.0m },
            new MealIngredient { MealID = 20, IngredientID = 20, Quantity = 0.2m },
            new MealIngredient { MealID = 20, IngredientID = 21, Quantity = 2.0m },
            new MealIngredient { MealID = 21, IngredientID = 32, Quantity = 1.0m },
            new MealIngredient { MealID = 21, IngredientID = 26, Quantity = 1.0m },
            new MealIngredient { MealID = 21, IngredientID = 29, Quantity = 1.0m },
            new MealIngredient { MealID = 22, IngredientID = 35, Quantity = 1.0m },
            new MealIngredient { MealID = 22, IngredientID = 41, Quantity = 1.0m },
            new MealIngredient { MealID = 22, IngredientID = 46, Quantity = 0.5m },
            new MealIngredient { MealID = 23, IngredientID = 32, Quantity = 1.0m },
            new MealIngredient { MealID = 23, IngredientID = 42, Quantity = 0.5m },
            new MealIngredient { MealID = 23, IngredientID = 46, Quantity = 0.5m },
            new MealIngredient { MealID = 24, IngredientID = 19, Quantity = 1.0m },
            new MealIngredient { MealID = 24, IngredientID = 29, Quantity = 1.0m },
            new MealIngredient { MealID = 24, IngredientID = 31, Quantity = 0.5m },
            new MealIngredient { MealID = 24, IngredientID = 26, Quantity = 0.5m },
            new MealIngredient { MealID = 25, IngredientID = 11, Quantity = 3.0m },
            new MealIngredient { MealID = 25, IngredientID = 12, Quantity = 2.0m },
            new MealIngredient { MealID = 25, IngredientID = 32, Quantity = 0.5m },
            new MealIngredient { MealID = 25, IngredientID = 23, Quantity = 1.0m },
            new MealIngredient { MealID = 26, IngredientID = 26, Quantity = 0.5m },
            new MealIngredient { MealID = 26, IngredientID = 28, Quantity = 1.0m },
            new MealIngredient { MealID = 26, IngredientID = 31, Quantity = 1.0m },
            new MealIngredient { MealID = 26, IngredientID = 27, Quantity = 0.2m },
            new MealIngredient { MealID = 27, IngredientID = 30, Quantity = 1.0m },
            new MealIngredient { MealID = 27, IngredientID = 34, Quantity = 1.0m },
            new MealIngredient { MealID = 28, IngredientID = 25, Quantity = 1.0m },
            new MealIngredient { MealID = 28, IngredientID = 47, Quantity = 0.5m },
            new MealIngredient { MealID = 28, IngredientID = 48, Quantity = 1.0m },
            new MealIngredient { MealID = 29, IngredientID = 36, Quantity = 1.0m },
            new MealIngredient { MealID = 29, IngredientID = 29, Quantity = 1.0m },
            new MealIngredient { MealID = 29, IngredientID = 39, Quantity = 0.5m },
            new MealIngredient { MealID = 30, IngredientID = 33, Quantity = 1.0m },
            new MealIngredient { MealID = 30, IngredientID = 39, Quantity = 0.5m },
            new MealIngredient { MealID = 30, IngredientID = 41, Quantity = 1.0m }




        };
        context.AddRange(mealIngredients);
        context.SaveChanges();
    }
}