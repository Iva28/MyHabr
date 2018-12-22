﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHabr.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Text { get; set; }

        [Required]
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
