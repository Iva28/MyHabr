using MyHabr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        Post AddPost(Post post);
        Post GetPost(int id);
        void AddComment(Comment comment);
    }
}
