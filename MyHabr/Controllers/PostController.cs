using Microsoft.AspNetCore.Mvc;
using MyHabr.Models;
using MyHabr.Services;
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
        }

        [HttpGet]
        public IActionResult All()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
            List<Post> posts = postService.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult PostInfo(int id)
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
            var post = postService.GetPost(id);
            if (post != null)
            {
                return View(post);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult AddComment(Comment c)
        {
            postService.AddComment(c);
            return RedirectToAction("PostInfo", "Post", new { c.Post.Id });
        }

        [HttpPost]
        public IActionResult NewPost(Post p)
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
            postService.AddPost(p);
            return RedirectToAction("Info", "User");
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
            var p = new Post();
            p.User = new User() { Id = Int32.Parse(Request.Cookies["user"])};
            return View(p);
        }
    }
}
