using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Entities;

namespace RecipeBook.WebUI.Controllers
{
    [Authorize]
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
        public ViewResult Edit (int recipeID)
        {
            Recipe recipe = recipeRepo.Recipes.FirstOrDefault(r => r.RecipeID == recipeID);
            return View(recipe);
        }

        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipeRepo.SaveRecipe(recipe);
                TempData["message"] = string.Format("{0} has been saved successfully", recipe.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //If there is something wrong
                return View(recipe);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Recipe());
        }
        [HttpPost]
        public ActionResult Delete(int recipeID)
        {
            Recipe deletedRecipe = recipeRepo.DeleteRecipe(recipeID);
            if(deletedRecipe != null)
            {
                TempData["message"] = string.Format("{0} was deleted succesfully", deletedRecipe.Name);
            }
            return RedirectToAction("Index");
        }
    }
}