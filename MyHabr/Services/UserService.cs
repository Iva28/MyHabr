using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHabr.Models;
using MyHabr.ViewModels;

namespace MyHabr.Services
{
    public class UserService : IUserService
    {
        private HabrDbContext context;

        public UserService(HabrDbContext context)
        {
            this.context = context;
        }

        public User GetUser(string login, string password)
        {
            return context.Users.ToList().Find(u => u.Login == login && u.Password == password);
        }

        public User GetUserById(int id)
        {
            return context.Users.ToList().Find(u => u.Id == id);
        }
    }
}
