using MyHabr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();
        Task<Post> AddPost(int userId, string title, string preview, string text, string img);
        Task<Post> GetPost(int id);
        Task<Comment> AddComment(int userId, int postId, string text);
    }
}
