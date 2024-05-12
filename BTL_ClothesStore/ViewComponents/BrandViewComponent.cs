using BTL_ClothesStore.Models;
using BTL_ClothesStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ClothesStore.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly IBrandRepository _brand;
        public BrandViewComponent(IBrandRepository brandRepository)
        {
            _brand = brandRepository;
        }
        public IViewComponentResult Invoke()
        {
            var brand = _brand.GetAllBrands().OrderBy(x => x.BrandName);
            return View(brand);
        }
    }
}
