using Gourmand.DTO;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository) => _restaurantRepository = restaurantRepository;

        [HttpGet("{ID}")]
        [TypeFilter(typeof(Filters.RestaurantFilters.EnsureIDExists))]
        public IActionResult GetRestaurantById(int ID)
        {
            var restaurant = HttpContext.Items["Restaurant"] as Restaurant;

            return Ok(new
            {
                restaurant.Name,
                restaurant.Address,
                restaurant.Email,
                restaurant.Number
            });       
        }

        [HttpPost]
        [TypeFilter(typeof(Filters.RestaurantFilters.EnsureNewRestaurant))]
        public IActionResult AddRestaurant([FromBody] RestaurantDTO newRestaurant)
        {
            _restaurantRepository.AddRestaurant(newRestaurant);

            return Ok();
        }

        [HttpPut("{ID}")]
        [TypeFilter(typeof(Filters.RestaurantFilters.EnsureIDExists))]
        public IActionResult UpdateRestaurant(int ID,[FromBody] RestaurantDTO restaurant)
        {
            _restaurantRepository.UpdateRestaurant(HttpContext.Items["Restaurant"] as Restaurant, restaurant);
            return NoContent();

        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(Filters.RestaurantFilters.EnsureIDExists))]
        public IActionResult DeleteClient(int ID)
        {
            _restaurantRepository.DeleteRestaurant(HttpContext.Items["Restaurant"] as Restaurant);
            return Ok();
        }

        [HttpGet("s/{ID}")]
        public IActionResult GetProducts(int ID)
        {
            return Ok(_restaurantRepository.GetProducts(ID));
        }
    }
}
