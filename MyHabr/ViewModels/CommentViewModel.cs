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
        public string Text { get; set; }
    }
}
