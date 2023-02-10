using SwaggerBlogSite.Models.AuthModels;
using SwaggerBlogSite.Models.AuthModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwaggerBlogSite.Controllers
{
    public class AccountController : Controller
    {
        AuthController auth = new AuthController();
        UserRepository repos = new UserRepository();

      
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            auth.Resgister(repos.GetNewUser(model));
            return RedirectToAction("Index", "Blog");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = repos.GetExistUser(model);
            auth.Authorize(user.Email, user.Password);
            return RedirectToAction("Index", "Blog");
        }
    }
}