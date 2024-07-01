using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface ICourierRepository
    {
        void AddCourier(CourierDTO newCourier);
        void UpdateCourier(Courier courier, CourierDTO updatedCourier);
        void DeleteCourier(Courier courier);

    }
}
