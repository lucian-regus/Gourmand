using Gourmand.DTO;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) => _productRepository = productRepository;

        [HttpGet("{ID}")]
        [TypeFilter(typeof(Filters.ProductFilters.EnsureIDExists))]
        public IActionResult GetProductByID(int ID) {
            var product = HttpContext.Items["Product"] as Product;

            return Ok(new
            {
                product.Name,
                product.Price
            });
        }

        [HttpPost]
        [TypeFilter(typeof(Filters.ProductFilters.EnsureNewProduct))]
        public IActionResult AddProduct([FromBody]ProductDTO product)
        {
            _productRepository.AddProduct(product);
            return Ok();
        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(Filters.ProductFilters.EnsureIDExists))]
        public IActionResult DeleteProduct(int ID)
        {
            _productRepository.DeleteProduct(HttpContext.Items["Product"] as Product);
            return Ok();
        }

        [HttpPut("{ID}")]
        [TypeFilter(typeof(Filters.ProductFilters.EnsureIDExists))]
        public IActionResult UpdateProduct(int ID, [FromBody] ProductDTO product)
        {
            _productRepository.UpdateProduct(HttpContext.Items["Product"] as Product,product);
            return NoContent();
        }
    }
}
