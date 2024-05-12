using Microsoft.AspNetCore.Mvc;
using BTL_ClothesStore.Models;
using BTL_ClothesStore.Repository;

namespace ClothesStore.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _category;
        public CategoryViewComponent(ICategoryRepository categoryRepository)
        {
            _category = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var category = _category.GetAllCategories().OrderBy( x => x.CategoryName);
            return View(category);
        }
    }
}
