using System.ComponentModel.DataAnnotations;

namespace Gourmand.Models
{
    public class Basket
    {
        public int BasketID { get; set; }
        
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        [Required]
        public int? Quantity { get; set; }
        public bool IsRemoved { get; set; }
    }
}
