using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserTag { get; set; }
        public List<CartItem> CartItems = new List<CartItem>();
        
    }
    
}
