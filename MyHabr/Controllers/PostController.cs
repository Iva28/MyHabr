using Microsoft.AspNetCore.Mvc;
using MyHabr.Models;
using MyHabr.Services;
using MyHabr.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MyHabr.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public void SetIsAuth()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            SetIsAuth();
            List<Post> posts = await postService.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> PostInfo(int id)
        {
            SetIsAuth();
            var post = await postService.GetPost(id);
            if (post != null) {
                return View(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel model)
        {
            SetIsAuth();
            Comment c = await postService.AddComment(Int32.Parse(Request.Cookies["user"]), model.PostId, model.Text);
            if (c!= null)
                return Json(new { success = true, c.User.Avatar, c.User.Email, Date = c.Date.ToString("g"), c.Text });
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(NewPostViewModel model)
        {
            SetIsAuth();
            await postService.AddPost(Int32.Parse(Request.Cookies["user"]), model.Title, model.Preview, model.Text, model.Image);
            return RedirectToAction("MyPage", "User");
        }
    }
}
