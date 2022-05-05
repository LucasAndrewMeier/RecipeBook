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
    }
}
