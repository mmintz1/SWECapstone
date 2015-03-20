using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ticketing.Framework.Mediators;
using Ticketing.Framework.Models.Account;

namespace Ticketing.Website.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var loginModel = new RegisterVM();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Login(RegisterVM user)
        {
            var mediator = new AccountMediator();

            var isAuthenticated = mediator.Authenticate(user);
            if (isAuthenticated)
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, "");
                string CookieContents = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, CookieContents) { Path = FormsAuthentication.FormsCookiePath };
                if (HttpContext.Response != null)
                {
                    HttpContext.Response.Cookies.Add(cookie);
                }

                //Session["UserAccount"] = mediator.GetUser(user.Email);

                return Redirect("/admin/eventList");
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", "Invalid credentials");
            }
            return PartialView(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            var registerModel = new RegisterVM();
            return View("~/Views/Account/Register.cshtml", registerModel);
        }

        [HttpPost]
        public ActionResult Register(RegisterVM user)
        {
            var mediator = new AccountMediator();
            if (user.Password != user.VerifyPassword)
                ModelState.AddModelError("ErrorMessage", "Passwords don't match");


            if (ModelState.IsValid)
            {
                bool success = mediator.RegisterUser(user);

                if (success)
                    return Redirect("/account/login");
                else
                    ModelState.AddModelError("ErrorMessage", "Unable to create account");

            }
            return PartialView(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
