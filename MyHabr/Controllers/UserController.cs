using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHabr.Models;
using MyHabr.Services;
using MyHabr.ViewModels;
using System;
using System.Web;

namespace MyHabr.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public void SetIsAuth()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            SetIsAuth();
            SignInViewModel model = new SignInViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var user = userService.GetUser(model.Login, model.Password);
            if (user != null) {
                Response.Cookies.Append("user", user.Id.ToString());
                SetIsAuth();
                return RedirectToAction("Info", "User");
            }
            else {
                SignInViewModel m = new SignInViewModel();
                ModelState.Clear();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Info()
        {
            SetIsAuth();
            var us = userService.GetUserById(Int32.Parse(Request.Cookies["user"]));
            return View(us);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("user");
            SetIsAuth();
            return RedirectToAction("All", "Post");
        }
    }
}
