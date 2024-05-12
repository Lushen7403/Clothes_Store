using BTL_ClothesStore.Models;

namespace BTL_ClothesStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ClothesStoreContext _context;
        public CategoryRepository(ClothesStoreContext context)
        {
            _context = context;
        }
        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Delete(string categoryID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public Category GetCategory(string categoryID)
        {
            return _context.Categories.Find(categoryID);
        }

        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
