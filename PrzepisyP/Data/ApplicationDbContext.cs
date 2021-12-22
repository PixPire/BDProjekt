using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrzepisyP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrzepisyP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RecipeGoesWellWith>().HasKey(table => new
            {
                table.RecipeId,
                table.GoesWellWithId
            });
            builder.Entity<RecipeFavourite>().HasKey(table => new
            {
                table.RecipeId,
                table.UserId
            });
            builder.Entity<Like>().HasKey(table => new {
                table.RecipeId,
                table.UserId
            });
            builder.Entity<RecipeCategoryJoin>().HasKey(table => new
            {
                table.RecipeId,
                table.CategoryId
            });
            builder.Entity<AccesoryFavourite>().HasKey(table => new
            {
                table.AccesoryId,
                table.UserId
            });
            builder.Entity<RecipeIngredient>().HasKey(table => new
            {
                table.RecipeId,
                table.IngredientId
            });
        }

        public DbSet<Accesory> Accesories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GoesWellWith> GoesWellWith { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeCategoryJoin> RecipeCategoriesJoin { get; set;}
        public DbSet<RecipeFavourite> RecipeFacourites { get; set; }
        public DbSet<RecipeGoesWellWith> recipeGoesWellWith { get; set; }
        public DbSet<RecipeIngredient> recipeIngredients { get; set; }
    }
}
