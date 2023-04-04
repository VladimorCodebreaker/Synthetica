using System;
using System.ComponentModel.DataAnnotations;

namespace Synthetica.Data.ViewModels
{
	public class RegistrationVM
	{
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required!")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Your Password Please!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "-> Passwords do not match!! <-")]
        public string ConfirmPassword { get; set; }
    }
}

