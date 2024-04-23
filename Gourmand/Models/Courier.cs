namespace Gourmand.Models
{
    public class Courier
    {
        public int CourierID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public ICollection<Order>? Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}
