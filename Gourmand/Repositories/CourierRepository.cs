using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using System.Diagnostics.Metrics;

namespace Gourmand.Repositories
{
    public class CourierRepository : ICourierRepository
    {
        private readonly GourmandDBContext _db;
        public CourierRepository(GourmandDBContext db) => _db = db;

        public void AddCourier(CourierDTO newCourier)
        {
            var courier = new Courier
            {
                Name = newCourier.Name,
                Username = newCourier.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(newCourier.Password),
                Email = newCourier.Email,
                Number = newCourier.Number,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            _db.Courier.Add(courier);
            _db.SaveChanges();
        }

        public void DeleteCourier(Courier courier)
        {
            courier.IsDeleted = true;
            _db.SaveChanges();
        }

        public void UpdateCourier(Courier courier, CourierDTO updatedCourier)
        {
            courier.Name = updatedCourier.Name;
            courier.Username = updatedCourier.Username;
            courier.Password = BCrypt.Net.BCrypt.HashPassword(updatedCourier.Password);
            courier.Email = updatedCourier.Email;
            courier.Number = updatedCourier.Number;
            courier.RegistrationDate = DateOnly.FromDateTime(DateTime.Now);
            _db.SaveChanges();
        }
    }
}
