using Lab_8_2_Net_4.Helpers;
using Lab_8_2_Net_4.Models;
using Lab_8_2_Net_4.ViewModel;

using Microsoft.AspNetCore.Mvc;

namespace Lab_8_2_Net_4.Controllers
{
    public class AccountController: Controller
    {
        private readonly ShopBanCamContext _context;


        public AccountController(ShopBanCamContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Account/Login")]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel account)
        {
            if(ModelState.IsValid)
            {
                var query = _context.Accounts.Where(p => p.Email == account.Email && p.Password == account.Password);

                var result = query.FirstOrDefault();

                if(result != null)
                {
                    SessionNJsonHelper.SetObjectAsJson(HttpContext.Session, "Account", result);
                    // đăng nhập thành công

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(account);
        }

        [HttpGet]
        [Route("/Account/SignUp")]
        public ViewResult SignUp()
        {
            ViewBag.isLogin = SessionNJsonHelper.GetObjectAsJson<Account>(HttpContext.Session, "Account") != null ? true : false;

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Account user)
        {
            if(ModelState.IsValid)
            {
                bool isExist = _context.Accounts.Any(p => p.Email == user.Email);
                if(isExist)
                {
                    user.Email = "Email already exit";
                    return View(user);

                }
                else
                {
                    _context.Accounts.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return View(user);
            }
        }
    }
}
