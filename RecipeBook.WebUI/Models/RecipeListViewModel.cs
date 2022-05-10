using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecipeBook.Domain.Entities;
namespace RecipeBook.WebUI.Models
{
    public class RecipeListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCuisine { get; set; }
    }
}