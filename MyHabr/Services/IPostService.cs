using MyHabr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Services
{
    public interface IPostService
    {
        void Initialize();
        List<Post> GetAllPosts();
        Post AddPost(int userId, string title, string preview, string text);
        Post GetPost(int id);
        void AddComment(int userId, int postId, string text);
    }
}
