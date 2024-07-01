using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly GourmandDBContext _db;
        public BasketRepository(GourmandDBContext db) => _db = db;

        public void AddItemToBasket(BasketDTO newItem)
        {
            var product = _db.Product.FirstOrDefault(x => x.ProductID == newItem.ProductID);
            var order = _db.Order.FirstOrDefault(x => x.OrderID == newItem.OrderID);

            Console.WriteLine("HEREEEEEE" + newItem.Quantity);

            Basket basket = new Basket()
            {
                Product = product,
                Order = order,
                Quantity = newItem.Quantity
            };

            _db.Basket.Add(basket);
            _db.SaveChanges();
        }

        public void RemoveItemFromBasket(BasketDTO toDelete)
        {
            var basketItem = _db.Basket.FirstOrDefault(x => x.ProductID == toDelete.ProductID && x.OrderID == toDelete.OrderID && x.Quantity == toDelete.Quantity && x.IsRemoved == false);

            basketItem.IsRemoved = true;
            _db.SaveChanges();
        }


    }
}
