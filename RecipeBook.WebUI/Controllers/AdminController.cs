using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;

namespace RecipeBook.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IRecipeRepo recipeRepo;
        // GET: Admin
        public AdminController(IRecipeRepo repo)
        {
            recipeRepo = repo;
        }
        public ViewResult Index()
        {
            return View(recipeRepo.Recipes);
        }
    }
}