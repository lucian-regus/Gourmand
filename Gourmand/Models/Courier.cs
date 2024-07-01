using System.ComponentModel.DataAnnotations;

namespace Gourmand.Models
{
    public class Courier
    {
        public int CourierID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Number { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public ICollection<Order>? Order { get; set; }
        public bool IsDeleted { get; set; }
        public int ForgotPasswordCode { get; set; }
    }
}
