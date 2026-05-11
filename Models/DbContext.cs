using Microsoft.EntityFrameworkCore;

namespace final_project.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealIngredient>().HasKey(m => new {m.IngredientID, m.MealID});
    }

    public DbSet<Meal> Meals {get;set;}
    public DbSet<Ingredient> Ingredients {get;set;}
    public DbSet<MealIngredient> MealIngredients {get;set;}
}