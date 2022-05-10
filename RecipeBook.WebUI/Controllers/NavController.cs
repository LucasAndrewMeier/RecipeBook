using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;

namespace RecipeBook.WebUI.Controllers
{
    public class NavController : Controller
    {
        
        // GET: Nav
        private IRecipeRepo Repo;
        public NavController(IRecipeRepo repo)
        {
            Repo = repo;
        }
        public PartialViewResult Menu(string cuisine = null)
        {
            ViewBag.SelectedCuisine = cuisine;

            IEnumerable<string> cuisines = Repo.Recipes.Select(x => x.Cuisine).Distinct().OrderBy(x => x);

            return PartialView(cuisines);
        }
    }
}