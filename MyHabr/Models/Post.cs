using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(1500, MinimumLength = 5)]
        public string Preview { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 5)]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
