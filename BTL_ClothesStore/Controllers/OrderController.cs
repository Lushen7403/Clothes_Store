using BTL_ClothesStore.Extension;
using BTL_ClothesStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTL_ClothesStore.Controllers
{
    public class OrderController : Controller
    {
        public double total;
        ClothesStoreContext DbContext = new ClothesStoreContext();
        public OrderController(ClothesStoreContext _context)
        {
            DbContext = _context;
        }
  
        public IActionResult Index()
        {
            if (HttpContext.Session.Get("UserAccount") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                
                var lstCart = HttpContext.Session.Get<List<CartModel>>("GioHang");
                if (lstCart != null)
                {
                    var useracc = HttpContext.Session.GetString("UserAccount");
                    var acc = DbContext.Accounts.SingleOrDefault(p => p.UserAccount == useracc);
                    var order = new OrderTable();
                    order.OrderDate = DateTime.Now;
                    order.AccountId = acc.AccountId;
                    foreach (var item in lstCart)
                    {
                        total += (item._price);
                    }
                    ViewBag.Total = total;
                    order.OrderTotal = total;
                    DbContext.OrderTables.Add(order);
                    DbContext.SaveChanges();

                    int orderId = order.OrderId;
                    List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                    foreach (var item in lstCart)
                    {
                        OrderDetail obj = new OrderDetail();
                        obj.OrderId = orderId;
                        obj.ProductId = item.product.ProductId;
                        obj.Quantity = item._quantity;
                        obj.Total = item._price;
                        lstOrderDetail.Add(obj);
                    }
                    DbContext.OrderDetails.AddRange(lstOrderDetail);
                    DbContext.SaveChanges();
                    return View();
                }
               else return RedirectToAction("Index", "Product");
            }

        }
        
    }
}
