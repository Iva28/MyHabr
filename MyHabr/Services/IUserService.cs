using MyHabr.Models;
using MyHabr.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string login, string password);
        Task<User> GetUserById(int id);
    }
}
