using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyHabr.Models
{
    public class HabrDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public HabrDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Post>().Property(b => b.Date).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>().Property(b => b.Date).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>().HasData(new {
                Id = 1,
                Email = "tikovka1@mail.ru",
                Login = "tikovka1",
                Password = "tikovka1",
                RegistrationDate = DateTime.Now,
                Avatar = "http://romanroadtrust.co.uk/wp-content/uploads/2018/01/profile-icon-png-898-300x300.png"
            },
            new
            {
                Id = 2,
                Email = "tikovka2@mail.ru",
                Login = "tikovka2",
                Password = "tikovka2",
                RegistrationDate = DateTime.Now,
                Avatar = "http://romanroadtrust.co.uk/wp-content/uploads/2018/01/profile-icon-png-898-300x300.png"
            },
            new
            {
                Id = 3,
                Email = "user@mail.ru",
                Login = "user",
                Password = "user",
                RegistrationDate = DateTime.Now,
                Avatar = "http://romanroadtrust.co.uk/wp-content/uploads/2018/01/profile-icon-png-898-300x300.png"
            });

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "posts.txt");
            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(File.ReadAllText(filePath));

            int postId = 1;
            int userId = 1;

            foreach (var p in posts) {
                if (postId == 3)
                    userId++;
                else if (postId == 5)
                    userId++;
                modelBuilder.Entity<Post>().HasData(new {
                    Id = postId, p.Title, p.Preview, p.Text, Date = DateTime.Now, p.Image, UserId = userId
                });
                postId++;
            }
        }
    }
}
