using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class CategoryDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
