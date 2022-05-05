using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Abstract
{
    public interface IRecipeRepo
    {
        IEnumerable<Recipe> Recipes { get; }
    }
}
