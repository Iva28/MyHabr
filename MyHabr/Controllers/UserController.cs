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

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
            SignInViewModel model = new SignInViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsAuth = false;
                return View(model);
            }

            var user = userService.GetUser(model.Login, model.Password);
            if (user != null)
            {
                Response.Cookies.Append("user", user.Id.ToString());
                ViewBag.IsAuth = true;
                return RedirectToAction("Info", "User");
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Info()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;

            var us = userService.GetUserById(Int32.Parse(Request.Cookies["user"]));
            return View(us);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("user");
            ViewBag.IsAuth = false;
            return RedirectToAction("All", "Post");
        }
    }
}
