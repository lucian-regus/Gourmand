using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.EntityFrameworkCore;

namespace Gourmand.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly GourmandDBContext _db;
        public RestaurantRepository(GourmandDBContext db) => _db = db;

        public void AddRestaurant(RestaurantDTO newRestaurant)
        {
            var restaurant = new Restaurant
            {
                Name = newRestaurant.Name,
                Username = newRestaurant.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(newRestaurant.Password),
                Email = newRestaurant.Email,
                Number = newRestaurant.Number,
                Address = newRestaurant.Address,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            _db.Restaurant.Add(restaurant);
            _db.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            _db.SaveChanges();
        }

        public void UpdateRestaurant(Restaurant restaurant, RestaurantDTO updatedRestaurant)
        {
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Username = updatedRestaurant.Username;
            restaurant.Password = BCrypt.Net.BCrypt.HashPassword(updatedRestaurant.Password);
            restaurant.Email = updatedRestaurant.Email;
            restaurant.Number = updatedRestaurant.Number;
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetProducts(int ID)
        {
            var restaurant = _db.Restaurant.Include(r => r.Products).FirstOrDefault(x => x.RestaurantID == ID);
             
            return restaurant.Products;
        }

    }
}
