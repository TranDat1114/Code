using Lab_7_2_Net_4.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lab_7_2_Net_4.Controllers
{
    public class HomeController: Controller
    {
        private readonly ShopBanCamContext _context;


        public HomeController(ShopBanCamContext context)
        {
            _context = context;

        }
        // GET: HomeController
        public async Task<ActionResult> Index(string catagory)
        {
            var danhMucSanPham = _context.Categories.ToList();
            ViewBag.catagories = danhMucSanPham;
            if(catagory.IsNullOrEmpty())
            {
                catagory = "camera";
            }
            var shopBanCamContext = _context.Products.Where(p => p.Category.CategoryName == catagory).Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductImages);

            return View(await shopBanCamContext.ToListAsync());
        }

        // GET: HomeController/Details/5
        public async Task<ActionResult> ProductDetails(int productId)
        {
            var productDetails = _context.Products.Where(p => p.ProductId == productId).Include(p => p.Brand).Include(p => p.Category).Include(p => p.ProductImages).Include(p => p.Reviews);
            var danhMucSanPham = _context.Categories.ToList();
            ViewBag.catagories = danhMucSanPham;
            return View(await productDetails.FirstOrDefaultAsync());
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
