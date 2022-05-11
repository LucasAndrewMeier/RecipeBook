using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Entities;
using RecipeBook.WebUI.Models;

namespace RecipeBook.WebUI.Controllers
{
    public class ScheduleController : Controller
    {
        private IRecipeRepo recipeRepo;
        public ScheduleController(IRecipeRepo repo)
        {
            recipeRepo = repo;
        }

        private Schedule GetSchedule()
        {
            Schedule schedule = (Schedule)Session["Schedule"];

            if (schedule == null)
            {
                schedule = new Schedule();
                Session["Schedule"] = schedule;
            }
            return schedule;
        }
        public RedirectToRouteResult AddToSchedule(Schedule schedule, int recipeID, string returnUrl)
        {
            Recipe recipe = recipeRepo.Recipes.FirstOrDefault(r => r.RecipeID == recipeID);

            if (recipe != null)
            {
                schedule.AddRecipe(recipe, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Index(Schedule schedule, string returnUrl)
        {
            return View(new ScheduleIndexViewModel
            {
                Schedule = schedule,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult RemoveFromSchedule(Schedule schedule, int recipeID, string returnUrl)
        {
            Recipe recipe = recipeRepo.Recipes.FirstOrDefault(r => r.RecipeID == recipeID);
            if(recipe != null)
            {
                schedule.RemoveLine(recipe);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Schedule schedule)
        {
            return PartialView(schedule);
        }
    }
}