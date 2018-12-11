﻿using Microsoft.AspNetCore.Mvc;
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
            List<Post> posts = postService.GetAllPosts();
            if (Request.Cookies["user"] != null)
                ViewBag.IsAuth = true;
            else
                ViewBag.IsAuth = false;
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

        public IActionResult AddPost(Post p)
        {
            postService.AddPost(p);
            return RedirectToAction("All", "Post");
        }
    }
}
