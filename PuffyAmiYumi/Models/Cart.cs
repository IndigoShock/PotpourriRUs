using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public bool CheckedOut { get; set; }
        public List<CartItem> CartItems { get; set; }
        
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
    }
    
}
