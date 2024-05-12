using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.Mvc.Core;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using BTL_ClothesStore.Models;

namespace ClothingStore.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {

        ClothesStoreContext db = new ClothesStoreContext();
        [Route("")]
        [Route("index")]

        public IActionResult Index()

        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.Products.AsNoTracking().OrderBy(x => x.ProductName);
            PagedList<Product> lst = new PagedList<Product>(lstSanPham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("NguoiDung")]
        public IActionResult NguoiDung(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstNguoidung = db.Accounts.AsNoTracking().OrderBy(x => x.AccountId);
            PagedList<Account> lst = new PagedList<Account>(lstNguoidung, pageNumber, pageSize);
            return View(lst);
        }
        [Route("PhanHoi")]
        public IActionResult PhanHoi(int? page)
        {
            var feedbackList = db.FeedBacks.Include(f => f.Account).ToList();

            // Truyền danh sách phản hồi qua ViewBag
            ViewBag.FeedBackList = feedbackList;
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstPhanhoi = db.FeedBacks.AsNoTracking().OrderBy(x => x.FeedBackId);
            PagedList<FeedBack> lst = new PagedList<FeedBack>(lstPhanhoi, pageNumber, pageSize);
            return View(lst);
        }
        [Route("HoaDon")]
        public IActionResult HoaDon(int? page)
        {
            var OrderTableList = db.OrderTables.Include(f => f.Account).ToList();
            // Truyền danh sách hóa đơn qua ViewBag
            ViewBag.OrderTable = OrderTableList;
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstHoaDon = db.OrderTables.AsNoTracking().OrderBy(x => x.OrderId);
            PagedList<OrderTable> lst = new PagedList<OrderTable>(lstHoaDon, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ChiTietHoaDon")]
        public IActionResult ChiTietHoaDon(int? orderID)
        {
            db.OrderDetails.Include(f => f.Product).ToList();
            // Truyền danh sách hóa đơn qua ViewBag
            var orderDetails = db.OrderDetails.Where(x => x.OrderId == orderID).ToList();
            return View(orderDetails);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()

        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(db.Brands.ToList(), "BrandId", "BrandName");

            return View();
        }

        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Product SanPham)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }

            return View(SanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int maSanPham)

        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(db.Brands.ToList(), "BrandId", "BrandName");
            var SanPham = db.Products.Find(maSanPham);
            return View(SanPham);
        }

        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Product SanPham)
        {

            if (ModelState.IsValid)
            {
                db.Entry(SanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }

            return View(SanPham);
        }

        [Route("XoaNguoiDung")]
        [HttpGet]
        public IActionResult XoaNguoiDung(int maNguoidung)
        {
            TempData["Message"] = "";
            var odertable = db.OrderTables.Where(x => x.AccountId == maNguoidung).ToList();
            if (odertable.Count() > 0)
            {
                TempData["Message"] = "Không xóa được người dùng này!";
                return RedirectToAction("NguoiDung", "HomeAdmin");
            }

            var feedback = db.FeedBacks.Where(x => x.AccountId == maNguoidung);
            if (feedback.Any()) db.RemoveRange(feedback);
            db.Remove(db.Accounts.Find(maNguoidung));
            db.SaveChanges();
            TempData["Message"] = "Người dùng đã được xóa!";
            return RedirectToAction("NguoiDung", "HomeAdmin");


        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int maSanPham)
        {
            TempData["Message"] = "";
            var oderDetail = db.OrderDetails.Where(x => x.ProductId == maSanPham).ToList();
            if (oderDetail.Count() > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này!";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            else
            {

                db.Remove(db.Products.Find(maSanPham));
                db.SaveChanges();
                TempData["Message"] = "Sản phẩm đã được xóa!";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");

            }
        }
        [Route("XoaPhanHoi")]
        [HttpGet]
        public IActionResult XoaPhanHoi(int maPhanHoi)
        {
                TempData["Message"] = "";
                db.Remove(db.FeedBacks.Find(maPhanHoi));
                db.SaveChanges();
                TempData["Message"] = "Phản hồi đã được xóa!";
                return RedirectToAction("PhanHoi", "HomeAdmin");
        }


    }

}

