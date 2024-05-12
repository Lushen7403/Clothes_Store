using BTL_ClothesStore.Extension;
using BTL_ClothesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ClothesStore.Controllers
{
    public class ContactController : Controller
    {
        ClothesStoreContext DbContext = new ClothesStoreContext();
        public ContactController(ClothesStoreContext _context)
        {
            DbContext = _context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendFeedBack(string content)
        {
            if (HttpContext.Session.Get("UserAccount") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if(content != null)
                {
                    FeedBack feedBack = new FeedBack();
                    var useracc = HttpContext.Session.GetString("UserAccount");
                    var acc = DbContext.Accounts.SingleOrDefault(p => p.UserAccount == useracc);
                    feedBack.FeedBackContent = content;
                    feedBack.AccountId = acc.AccountId;
                    DbContext.FeedBacks.Add(feedBack);
                    DbContext.SaveChanges();
                    return View();
                }
                return RedirectToAction(nameof(Index));  
            }
            
        }
    }
}
