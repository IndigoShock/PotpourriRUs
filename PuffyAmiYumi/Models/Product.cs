namespace PuffyAmiYumi.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public string SKU { get; set; }
    }
}