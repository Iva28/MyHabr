using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyHabr.Models;
using Newtonsoft.Json;

namespace MyHabr.Services
{
    public class PostService : IPostService
    {
        private HabrDbContext context;

        public PostService(HabrDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await context.Posts.ToListAsync();
        }

        public async Task<Post> GetPost(int id)
        {
           return await context.Posts.FindAsync(id);
        }

        public async Task<Comment> AddComment(int userId, int postId, string text)
        {
            var comment = new Comment();
            comment.Post = context.Posts.Find(postId);
            comment.User = context.Users.Find(userId);
            comment.Text = text;
            context.Comments.Add(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<Post> AddPost(int userId, string title, string preview, string text, string img)
        {
            var post = new Post();
            post.User = context.Users.Find(userId);
            post.Title = title;
            post.Preview = preview;
            post.Text = text;
            post.Image = img;
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }
    }
}
