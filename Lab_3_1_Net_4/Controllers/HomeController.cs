using System.Diagnostics;

using Lab_3_1_Net_4.Models;

using Microsoft.AspNetCore.Mvc;

namespace Lab_3_1_Net_4.Controllers
{
    public class HomeController: Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var chuyenNganh = new ChuyenNganh()
            {
                cacChuyenNganh = new List<ChuyenNganh>()
                {
                    new("/assets/TKĐH-1.png", @"thiết kế đồ họa"),
                    new("/assets/LapTrinhMoBile1200x628.png", @"lập trình máy tính-thiết bị di động"),
                    new("/assets/LapTrinhWebsite1200x628.png", @"thiết kế website"),
                    new("/assets/PhatTrienPhanMem1200x628.png", @"cntt-ứng dụng phần mềm")
                }
            };
            return View(chuyenNganh);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}