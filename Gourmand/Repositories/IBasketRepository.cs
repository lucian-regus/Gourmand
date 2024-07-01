using Gourmand.DTO;

namespace Gourmand.Repositories
{
    public interface IBasketRepository
    {
        void AddItemToBasket(BasketDTO newItem);
        void RemoveItemFromBasket(BasketDTO TOItem);
    }
}
