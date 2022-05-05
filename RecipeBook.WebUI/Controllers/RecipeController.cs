using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;

namespace RecipeBook.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeRepo recipeRepo;
        // GET: Recipe
        public RecipeController(IRecipeRepo recipeRepo)
        {
            this.recipeRepo = recipeRepo;
        }
        public ViewResult List()
        {
            return View(recipeRepo.Recipes);
        }
    }
}