using BTL_ClothesStore.Models;

namespace BTL_ClothesStore.Repository
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(string categoryID);
        Category GetCategory(string categoryID);
        IEnumerable<Category> GetAllCategories();
    }
}


