using Gourmand.Data;
using Gourmand.Models;
using System.Diagnostics.Metrics;

namespace Gourmand.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GourmandDBContext _db;
        public CategoryRepository(GourmandDBContext db) => _db = db;
        public void AddCategory(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            category.IsDeleted = true;
            _db.SaveChanges();
        }
    }
}
