using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyHabr.Models;

namespace MyHabr.Services
{
    public class UserService : IUserService
    {
        private HabrDbContext context;

        public UserService(HabrDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(string login, string password)
        {
            return await context.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}
