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
        User GetUser(string login, string password);
        User GetUserById(int id);
    }
}
