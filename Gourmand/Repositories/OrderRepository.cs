using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GourmandDBContext _db;
        public OrderRepository(GourmandDBContext db) => _db = db;


        public void AddOrder(OrderDTO newOrder)
        {
            var client = _db.Client.FirstOrDefault(x => x.ClientID == newOrder.ClientID);
            var courier = _db.Courier.FirstOrDefault(x => x.CourierID == newOrder.CourierID);
            var restaurant = _db.Restaurant.FirstOrDefault(x => x.RestaurantID == newOrder.RestaurantID);

            Order order = new Order()
                {
                Address = newOrder.Adress,
                OrderDate = DateTime.Now,
                Courier = courier,
                Client = client,
                Restaurant = restaurant
            };
            _db.Order.Add(order);
            _db.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            order.IsDeleted = true;
            _db.SaveChanges();
        }
    }
}
