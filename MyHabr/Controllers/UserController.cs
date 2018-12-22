using Microsoft.AspNetCore.Mvc;
using MyHabr.Services;
using MyHabr.ViewModels;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            var user = await userService.GetUser(model.Login, model.Password);
            if (user != null) {
                Response.Cookies.Append("user", user.Id.ToString());
                SetIsAuth();
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            SetIsAuth();
            var us = await userService.GetUserById(Int32.Parse(Request.Cookies["user"]));
            return View(us);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("user");
            SetIsAuth();
            return Ok();
            //return RedirectToAction("All", "Post");
        }
    }
}
