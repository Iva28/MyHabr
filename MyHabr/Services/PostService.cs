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

        public void Initialize()
        {
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new User()
                {
                    Email = "user@mail.ru",
                    Login = "user",
                    Password = "user",
                    RegistrationDate = DateTime.Now,
                    Avatar = "http://romanroadtrust.co.uk/wp-content/uploads/2018/01/profile-icon-png-898-300x300.png"
                });
                context.SaveChanges();
            }

            if (context.Posts.Count() == 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "posts.txt");
                List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(File.ReadAllText(filePath));

                foreach (var p in posts)
                {
                    context.Posts.Add(new Post()
                    {
                        Title = p.Title,
                        Preview = p.Preview,
                        Text = p.Text,
                        Date = DateTime.Now,
                        Image = p.Image,
                        User = context.Users.FirstOrDefault()
                    });
                }
                context.SaveChanges();
            }
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
