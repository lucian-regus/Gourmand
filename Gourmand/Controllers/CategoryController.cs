using Gourmand.DTO;
using Gourmand.Models;
using Gourmand.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gourmand.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        [HttpGet("{ID}")]
        [TypeFilter(typeof(Filters.CategoryFilters.EnsureIDExists))]
        public IActionResult GetCategoryById(int ID)
        {
            var category = HttpContext.Items["Category"] as Category;

            return Ok(new
            {
                category.Name
            });
        }

        [HttpPost]
        [TypeFilter(typeof(Filters.CategoryFilters.EnsureUniqueName))]
        public IActionResult AddCategory([FromBody] CategoryDTO category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };

            _categoryRepository.AddCategory(newCategory);

            return Ok(category);
        }

        [HttpDelete("{ID}")]
        [TypeFilter(typeof(Filters.CategoryFilters.EnsureIDExists))]
        public IActionResult DeleteCategory(int ID)
        {
            _categoryRepository.DeleteCategory(HttpContext.Items["Category"] as Category);
            return Ok();
        }
    }
}
