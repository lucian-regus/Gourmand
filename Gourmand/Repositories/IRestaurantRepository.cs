using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface IRestaurantRepository
    {
        void AddRestaurant(RestaurantDTO newRestaurant);
        void UpdateRestaurant(Restaurant restaurant,RestaurantDTO updatedRestaurant);
        void DeleteRestaurant(Restaurant restaurant);

        IEnumerable<Product> GetProducts(int ID);
    }
}
