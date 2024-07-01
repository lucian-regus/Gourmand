using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface IOrderRepository
    {
        public void AddOrder(OrderDTO order);
        public void DeleteOrder(Order order);
    }
}
