using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Concrete
{
    public class EFRecipeRepo : IRecipeRepo
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Recipe> Recipes
        {
            get { return context.Recipes; }
        }

        public void SaveRecipe(Recipe recipe)
        {
            if(recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe dbEntry = context.Recipes.Find(recipe.RecipeID);
                if(dbEntry != null)
                {
                    dbEntry.Name = recipe.Name;
                    dbEntry.Cuisine = recipe.Cuisine;
                    dbEntry.Ingredients = recipe.Ingredients;
                    dbEntry.Directions = recipe.Directions;
                }
            }
            context.SaveChanges();
        }
        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe dbEntry = context.Recipes.Find(recipeID);
            if(dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
