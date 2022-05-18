using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecipeBook.WebUI.Models;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Concrete;
using System.Security.Cryptography;
namespace RecipeBook.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileRepo ProfileRepo;
        public ProfileController(IProfileRepo repo)
        {
            ProfileRepo = repo;
        }
        // GET: Profile
        public ActionResult Index()
        {
            if (Session["ProfileID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Profile profile)
        {
            RegistrationViewModel model = new RegistrationViewModel();
            if (ModelState.IsValid)
            {
                var check = ProfileRepo.Profiles.FirstOrDefault(s => s.Email == model.Email);
                if (check == null)
                {
                    model.Password = GetMD5(model.Password);
                    ProfileRepo.SaveProfile(profile);
                    TempData["message"] = string.Format("{0} has been saved successfully", profile.FirstName);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = ProfileRepo.Profiles.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["ProfileID"] = data.FirstOrDefault().ProfileID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}