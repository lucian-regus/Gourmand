namespace Gourmand.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<Basket> Basket { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int CourierID { get; set; }
        public Courier Courier { get; set; }

        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

        public bool IsDeleted { get; set; }
    }
}
