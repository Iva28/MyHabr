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

        public Post AddPost(Post post)
        {
            post.Date = DateTime.Now;
            post.User = context.Users.Find(post.User.Id);
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public List<Post> GetAllPosts()
        {
            /*Post post = new Post()
              {
                  Title = "Любая интернет-компания обязана тайно изменить программный код по требованию властей",
                  Preview = "6 декабря 2018 года парламент Австралии принял Assistance and Access Bill 2018 — поправки к Telecommunications Act 1997 о правилах оказания услуг электросвязи.",
                  Text = "Говоря юридическим языком, эти поправки «устанавливают нормы для добровольной и обязательной помощи телекоммуникационных компаний правоохранительным органам и спецслужбам в отношении технологий шифрования после получения запросов на техническую помощь».",
                  Date = DateTime.Now,
                  User = new User() {
                      Email = "user@mail.ru",
                      Login = "user",
                      Password = "user",
                      RegistrationDate = DateTime.Now,
                      Avatar = "user"
                  },
              };

              context.Posts.Add(post);
              context.SaveChanges();*/

            return context.Posts.ToList();
        }

        public Post GetPost(int id)
        {
            return GetAllPosts().Find(p => p.Id == id);
        }

        public void AddComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.Post = context.Posts.Find(comment.Post.Id);
            comment.User = context.Users.Find(comment.User.Id);
            context.Comments.Add(comment);
            context.SaveChanges();            
        }
    }
}
