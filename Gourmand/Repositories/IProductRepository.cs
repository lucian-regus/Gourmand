using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(ProductDTO product);
        void UpdateProduct(Product product, ProductDTO newProduct);
        void DeleteProduct(Product product);
    }
}
