using BTL_ClothesStore.Models;

namespace BTL_ClothesStore.Repository
{
    public interface IBrandRepository
    {
        Brand Add(Brand brand);
        Brand Update(Brand brand);
        Brand Delete(string brandID);
        Brand GetBrand(string brandID);
        IEnumerable<Brand> GetAllBrands();
    }
}
