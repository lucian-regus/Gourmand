using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;

namespace Gourmand.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GourmandDBContext _db;
        public ProductRepository(GourmandDBContext db) => _db = db;
        public void AddProduct(ProductDTO product)
        {
            var category = _db.Category.FirstOrDefault(x => x.CategoryID == product.CategoryID);
            var restaurant = _db.Restaurant.FirstOrDefault(x => x.RestaurantID == product.RestaurantID);

            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Category = category,
                Restaurant = restaurant
            };

            _db.Product.Add(newProduct);
            _db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            product.IsDeleted = true;
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product,ProductDTO newProduct)
        {
            var category = _db.Category.FirstOrDefault(x => x.CategoryID == newProduct.CategoryID);

            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Category = category;

            _db.SaveChanges();
        }
    }
}
