using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Domain.Entities
{
    public class Recipe
    {
        [HiddenInput(DisplayValue = false)]
        public int RecipeID { get; set; }

        [Required(ErrorMessage = "Please enter a recipe name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a cuisine type")]
        public string Cuisine { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter the recipes ingredients")]
        public string Ingredients { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter the recieps directions")]
        public string Directions { get; set; }
        
    }
}
