using BTL_ClothesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class AccountController : Controller
    {
        ClothesStoreContext DbContext = new ClothesStoreContext();
        public AccountController(ClothesStoreContext _context)
        {
            DbContext = _context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserAccount") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        public IActionResult Login(Account user)
        {
            if (HttpContext.Session.GetString("UserAccount") == null)
            {
                var u = DbContext.Accounts.Where(x => x.UserAccount.Equals(user.UserAccount) && x.UserPassword.Equals(user.UserPassword)).FirstOrDefault();
                if (u != null)
                {
                    
                   
                    HttpContext.Session.SetString("UserAccount", u.UserAccount.ToString());
                    if (u.RoleId == 1)
                    {
                        return RedirectToAction("Index", "HomeAdmin", new {area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();

        }
        public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserAccount");
            return RedirectToAction("Login");

        }


        [HttpGet]
        public IActionResult Register()
        {
            
            
                return View();
            
        }

        [HttpPost]
        public IActionResult Register([Bind("UserAccount", "UserName", "UserPassword", "UserEmail", "UserPhone", "UserAddress")] Account Member)
        {
            // tai khoan nguoi dung
            Member.RoleId = 2;
           
                if (ModelState.IsValid)
                {
                    DbContext.Accounts.Add(Member);
                    DbContext.SaveChanges();
                    return RedirectToAction(nameof(Login));
                }
            
            return View();
        }
    }
}
