using Gourmand.DTO;
using Gourmand.Filters.OrderFilters;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        [HttpPost]
        [TypeFilter(typeof(Filters.OrderFilters.EnsureIDsExist))]
        public IActionResult AddOrder([FromBody]OrderDTO order)
        {
            _orderRepository.AddOrder(order);
            return Ok(order);
        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(Filters.OrderFilters.EnsureIDExists))]
        public IActionResult DeleteOrder(int ID)
        {
            _orderRepository.DeleteOrder(HttpContext.Items["Order"] as Order);
            return Ok();
        }
    }
}
