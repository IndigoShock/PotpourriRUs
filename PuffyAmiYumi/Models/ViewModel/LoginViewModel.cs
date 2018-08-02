using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuffyAmiYumi.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<Order> order { get; set; }

        public List<OrderItems> orderItems { get; set; }
    }
}