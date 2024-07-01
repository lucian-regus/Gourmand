using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class ProductDTO
    {
        [Required]
        public string? Name {  get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
    }
}
