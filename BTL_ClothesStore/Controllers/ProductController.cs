using BTL_ClothesStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ClothesStore.Controllers
{
    public class ProductController : Controller
    {
        ClothesStoreContext DbContext = new ClothesStoreContext();
        public ProductController(ClothesStoreContext _context)
        {
            DbContext = _context;
        }
        [HttpGet]
        public IActionResult Index(int ?page)
        {
            int pageSize = 8;
            ViewBag.Brand = DbContext.Brands;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = DbContext.Products.AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> list = new PagedList<Product>(products, pageNumber, pageSize);
            return View(list);

        }
        [HttpGet]
        public IActionResult ProductByCategory(int id, int? page)
        {
            int pageSize = 8;
            ViewBag.Brand = DbContext.Brands;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = DbContext.Products.Where(x => x.CategoryId == id).AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> list = new PagedList<Product>(products, pageNumber, pageSize);
            return View(list);
        }
        [HttpGet]
        public IActionResult ProductByBrand(int id, int? page)
        {
            int pageSize = 8;
            ViewBag.Brand = DbContext.Brands;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = DbContext.Products.Where(x => x.BrandId == id).AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> list = new PagedList<Product>(products, pageNumber, pageSize);
            return View(list);
        }
        [HttpGet]
        public IActionResult ProductDetail(int id)
        {
            var product = DbContext.Products.Find(id);
            ViewBag.Brand = DbContext.Brands;
            return View(product);
        }
    }
}
