using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.WebUI.Models;
using RecipeBook.WebUI.Infrastructure.Abstract;
using RecipeBook.WebUI.HtmlHelpers;
using RecipeBook.Domain.Concrete;
using RecipeBook.Domain.Entities;

namespace RecipeBook.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if(authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ViewResult Registration()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(Profile objNewUser)
        {
            try
            {
                using (var context = new EFDbContext())
                {
                    var chkUser = (from s in context.Profiles where s.UserName == objNewUser.UserName || s.Email == objNewUser.Email select s).FirstOrDefault();
                    if (chkUser == null)
                    {
                        var keyNew = Helper.GeneratePassword(10);
                        var password = Helper.EncodePassword(objNewUser.Password, keyNew);
                        objNewUser.Password = password;
                        objNewUser.VCode = keyNew;
                        context.Profiles.Add(objNewUser);
                        context.SaveChanges();
                        ModelState.Clear();
                        return RedirectToAction("Login", "Account");
                    }
                    ViewBag.ErrorMessage = "User is already in the system";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "Some exception occured" + e;
                return View();
            }
        }
    }
}