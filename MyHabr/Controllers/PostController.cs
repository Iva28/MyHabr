using Microsoft.AspNetCore.Mvc;
using MyHabr.Models;
using MyHabr.Services;
using MyHabr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
            postService.Initialize();
        }

        public void SetIsAuth()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
        }

        [HttpGet]
        public IActionResult All()
        {
            SetIsAuth();
            List<Post> posts = postService.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult PostInfo(int id)
        {
            SetIsAuth();
            var post = postService.GetPost(id);
            if (post != null) {
                return View(post);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel model)
        {
            SetIsAuth();
            if (ModelState.IsValid) {
                postService.AddComment(Int32.Parse(Request.Cookies["user"]), model.PostId, model.Text);
            }
            return RedirectToAction("PostInfo", "Post", new { id = model.PostId });
        }

        [HttpPost]
        public IActionResult NewPost(NewPostViewModel model)
        {
            SetIsAuth();
            if (ModelState.IsValid) {
                postService.AddPost(Int32.Parse(Request.Cookies["user"]), model.Title, model.Preview, model.Text, model.Image);
                return RedirectToAction("Info", "User");
            }
            return View(model);
        }

        //[HttpGet]
        //public IActionResult NewPost()
        //{
        //    SetIsAuth();
        //    NewPostViewModel model = new NewPostViewModel();
        //    return View(model);
        //}
    }
}
