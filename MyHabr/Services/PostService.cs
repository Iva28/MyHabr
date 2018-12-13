using System;
using System.Collections.Generic;
using System.Linq;
using MyHabr.Models;

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
            if (context.Posts.Count() == 0)
            {
                context.Posts.Add(new Post()
                {
                    Title = "Любая интернет-компания обязана тайно изменить программный код по требованию властей",
                    Preview = "6 декабря 2018 года парламент Австралии принял Assistance and Access Bill 2018 — поправки к Telecommunications Act 1997 о правилах оказания услуг электросвязи.",
                    Text = "Говоря юридическим языком, эти поправки «устанавливают нормы для добровольной и обязательной помощи телекоммуникационных компаний правоохранительным органам и спецслужбам в отношении технологий шифрования после получения запросов на техническую помощь».",
                    Date = DateTime.Now,
                    User = new User()
                    {
                        Email = "user@mail.ru",
                        Login = "user",
                        Password = "user",
                        RegistrationDate = DateTime.Now,
                        Avatar = "user"
                    }
                });
                context.SaveChanges();
            }
        }

        public List<Post> GetAllPosts()
        {
            return context.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return GetAllPosts().Find(p => p.Id == id);
        }

        public void AddComment(int userId, int postId, string text)
        {
            var comment = new Comment();
            comment.Post = context.Posts.Find(postId);
            comment.User = context.Users.Find(userId);
            comment.Text = text;
            //comment.Date = DateTime.Now; //default in database
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public Post AddPost(int userId, string title, string preview, string text)
        {
            var post = new Post();
            post.User = context.Users.Find(userId);
            post.Title = title;
            post.Preview = preview;
            post.Text = text;
            //post.Date = DateTime.Now; //default in database
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }
    }
}
