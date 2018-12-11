using MyHabr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Services
{
    public interface ICommentService
    {
        List<Comment> GetComments(int id);
        Comment AddComment(string text);
    }
}
