using System.ComponentModel.DataAnnotations;

namespace Gourmand.DTO
{
    public class OrderDTO
    {
        [Required]
        public string? Adress { get; set; }
        public int ClientID { get; set; }
        public int CourierID { get; set; }
        public int RestaurantID { get; set; }
    }
}
