using Lab_6_3_Net_4.Models;

using Microsoft.AspNetCore.Mvc;

namespace Lab_6_3_Net_4.Controllers
{
    public class HomeController: Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Products = ListProduct.Products;
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if(ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                ListProduct.Products.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
