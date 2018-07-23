using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public List<OrderItems> Products { get; set; }
        public decimal Total { get; set; }

    }
}
