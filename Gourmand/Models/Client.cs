using System.ComponentModel.DataAnnotations;

namespace Gourmand.Models
{
    public class Client
    {
        public int ClientID { get; set; }
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
        [Required]
        public DateOnly RegistrationDate { get; set; }
        [Required]
        public ICollection<Order>? Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
