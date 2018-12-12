using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Preview { get; set; }
        public string Text { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
