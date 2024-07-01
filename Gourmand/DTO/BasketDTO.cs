using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class BasketDTO
    {
        [Required]
        public int? ProductID { get; set; }
        [Required]
        public int? OrderID { get; set; }
        [Required]
        public int? Quantity { get; set; }
    }
}
