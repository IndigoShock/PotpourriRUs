using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public bool Purchased { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductIMG { get; set; }
        public int Quantity { get; set; }
    }
}
