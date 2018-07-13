using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Birthday { get; set; }

        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The Passwords you had input don't seem to match"), Required]
        public string ConfirmPassword { get; set; }
    }
}
