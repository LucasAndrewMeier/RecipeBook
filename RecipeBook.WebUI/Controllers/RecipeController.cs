using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;
using RecipeBook.WebUI.Models;

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

        public int PageSize = 5;
        public ViewResult List(int page = 1)
        {
            RecipeListViewModel model = new RecipeListViewModel
            {
                Recipes = recipeRepo.Recipes.OrderBy(p => p.RecipeID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = recipeRepo.Recipes.Count()
                }
            };
            return View(model);
        }
    }
}