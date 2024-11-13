namespace OnlineStore.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(ICategory category);
        List<ICategory> GetAllCategories();
    }
}
