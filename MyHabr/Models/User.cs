using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHabr.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Avatar { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
