using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public class CategoryService : ICategoryService
    {
        private List<ICategory> _categories;

        public CategoryService()
        {
            _categories = [];
        }

        public void AddCategory(ICategory category)
        {
            _categories.Add(category);
        }

        public List<ICategory> GetAllCategories()
        {
            return _categories;
        }
    }
}
