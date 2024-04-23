namespace Gourmand.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public ICollection<Menu> Menu { get; set; }
        public ICollection<Basket> Basket { get; set; }
    }
}
