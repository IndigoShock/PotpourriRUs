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
        public string FullName { get; set; }
        public string CreditCard { get; set; }
        public string NameOnCard { get; set; }
        public string Date { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Business { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<OrderItems> Products { get; set; }
        public decimal Total { get; set; }

    }
}
