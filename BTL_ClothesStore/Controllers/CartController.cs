using BTL_ClothesStore.Extension;
using BTL_ClothesStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ClothesStore.Controllers
{
    public class CartController : Controller
    {


        ClothesStoreContext DbContext = new ClothesStoreContext();
        public CartController(ClothesStoreContext _context)
        {
            DbContext = _context;
        }
        public List<CartModel> carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartModel>>("GioHang");
                if(data == null) {
                    data = new List<CartModel>();
                }
                return data;
            }
     
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(carts);
        }
        public IActionResult AddToCart(int id, int quantity)
        {
            var myCart = carts;
            var item = myCart.SingleOrDefault(p => p.product.ProductId == id);
            if(item == null)
            {
                var _product = DbContext.Products.SingleOrDefault(p => p.ProductId == id);
                item = new CartModel
                {
                    product = _product,
                    _quantity = quantity,
                    _price = (double)(quantity * _product.ProductPrice)
                };
                myCart.Add(item);
            }
            else
            {
                var _product = DbContext.Products.SingleOrDefault(p => p.ProductId == id);
                item._quantity += quantity;
                item._price += quantity*_product.ProductPrice;
            }
      
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var myCart = carts;
            var item = myCart.SingleOrDefault(r => r.product.ProductId == id);
            myCart.Remove(item);
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction(nameof(Index));
        }
    }
}
