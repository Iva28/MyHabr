using System.ComponentModel.DataAnnotations;

namespace MyHabr.ViewModels
{
    public class NewPostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters")]
        public string Title { get; set; }

        [Display(Name = "Preview")]
        [Required(ErrorMessage = "Preview is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Preview must be between 5 and 500 characters")]
        public string Preview { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Text is required")]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Text must be between 5 and 5000 characters")]
        public string Text { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}
