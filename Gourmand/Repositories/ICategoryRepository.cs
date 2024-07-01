using Gourmand.Models;

namespace Gourmand.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
    }
}
