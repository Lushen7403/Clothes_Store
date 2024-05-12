using BTL_ClothesStore.Models;

namespace BTL_ClothesStore.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ClothesStoreContext _context;
        public BrandRepository(ClothesStoreContext context)
        {
            _context = context;
        }
        public Brand Add(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public Brand Delete(string brandID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands;
        }

        public Brand GetBrand(string brandID)
        {
            return _context.Brands.Find(brandID);
        }

        public Brand Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return brand;
        }
    }
}
