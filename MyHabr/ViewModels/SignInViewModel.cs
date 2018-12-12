using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHabr.ViewModels
{
    public class SignInViewModel
    {
      [Required(ErrorMessage = "Login is required")]
      public string Login { get; set; }

      [DataType(DataType.Password)]
      [Required(ErrorMessage = "Password is required")]
      public string Password { get; set; }
    }
}
