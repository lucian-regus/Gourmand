using Gourmand.DTO;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository) => _basketRepository = basketRepository;

        [HttpPost]
        [TypeFilter(typeof(Filters.BasketFilters.EnsureUniqueBasketItem))]
        public IActionResult AddProductToBasket([FromBody]BasketDTO newItem) 
        {
            _basketRepository.AddItemToBasket(newItem);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProductFromBasket([FromBody] BasketDTO toItem)
        {
            _basketRepository.RemoveItemFromBasket(toItem);

            return Ok();
        }
    }
}
