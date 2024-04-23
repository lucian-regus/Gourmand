namespace Gourmand.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Basket> Basket { get; set; }
    }
}
