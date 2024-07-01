using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gourmand.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public ICollection<Order> Order { get; set; }
        public ICollection<Product> Products { get; set; } = [];
        public bool IsDeleted { get; set; }
        public int ForgotPasswordCode { get; set; }
    }
}
