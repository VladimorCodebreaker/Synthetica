using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Synthetica.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}

