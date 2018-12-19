using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyHabr.ViewModels
{
    public class CommentViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int PostId { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Comment is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Text must be between 5 and 500 characters")]
        public string Text { get; set; }
    }
}
