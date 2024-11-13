using OnlineStore.Interfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class CategoryController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void AddCategory(string categoryName)
        {
            var category = new Category(categoryName);
            _categoryService.AddCategory(category);
        }

        public List<ICategory> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }
    }
}
