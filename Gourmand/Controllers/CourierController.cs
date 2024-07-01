using Gourmand.DTO;
using Gourmand.Filters.ClientFilters;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourierController : ControllerBase
    {
        private readonly ICourierRepository _courierRepository;

        public CourierController(ICourierRepository courierRepository) => _courierRepository = courierRepository;

        [HttpGet("{ID}")]
        [TypeFilter(typeof(Filters.CourierFilters.EnsureIDExists))]
        public IActionResult GetCourierById(int ID)
        {
            var courier = HttpContext.Items["Courier"] as Courier;

            return Ok(new
            {
                courier.Name,
                courier.Email,
                courier.Number
            });
        }

        [HttpPost]
        [TypeFilter(typeof(Filters.CourierFilters.EnsureNewCourier))]
        public IActionResult AddCourier([FromBody] CourierDTO newCourier)
        {
            _courierRepository.AddCourier(newCourier);

            return Ok();
        }

        [HttpPut("{ID}")]
        [TypeFilter(typeof(Filters.CourierFilters.EnsureIDExists))]
        public IActionResult UpdateCourier(int ID, [FromBody] CourierDTO courier)
        {
            _courierRepository.UpdateCourier(HttpContext.Items["Courier"] as Courier, courier);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(Filters.CourierFilters.EnsureIDExists))]
        public IActionResult DeleteCourier(int ID)
        {
            _courierRepository.DeleteCourier(HttpContext.Items["Courier"] as Courier);
            return Ok();
        }
    }
}
