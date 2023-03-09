using Microsoft.AspNetCore.Mvc;

namespace Lab_5_1_Net_4.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Home/London")]
        public IActionResult London()
        {
            return View();
        }
        [Route("Home/Paris")]
        public IActionResult Paris()
        {
            return View();
        }
        [Route("Home/HoChiMinh")]
        public IActionResult HoChiMinh()
        {
            return View();
        }
        [Route("Home/Tokyo")]
        public IActionResult Tokyo()
        {
            return View();
        }
    }
}
