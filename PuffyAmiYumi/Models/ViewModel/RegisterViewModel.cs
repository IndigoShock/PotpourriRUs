using System;
using System.ComponentModel.DataAnnotations;

namespace PuffyAmiYumi.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The Passwords you had input don't seem to match"), Required]
        public string ConfirmPassword { get; set; }
    }
}