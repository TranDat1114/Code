using Lab_3_2_Net_4.Models;

using Microsoft.AspNetCore.Mvc;

namespace Lab_3_2_Net_4.Controllers
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
            NoiDung CacNoiDung = new NoiDung()
            {
                listProduct = new List<SanPham>
                {
                    new SanPham() { ProductName = "IPhone 11 Pro Max 64GB",Image="/assets/anhIphone.png", Discount = 2000000, Sale = 1512000, Price = 33990000,Review=439,StarReview=new(9),Description= new()
                {
                    ManHinh="1242 x 2688 Pixels 6.5 inch",Camera="Triple 12MP Ultra Wide",Pin="Lâu hơn Iphone Xs Max 5h",RAM="4 GB",CPU="Apple A13 Bionic",
                    HĐH="IOS 13"
                } },
                    new SanPham() { ProductName = "IPhone 11 Pro Max 256GB",Image="/assets/anhIphone.png", Discount = 1500000, Sale = 1689000, Price = 33990000,Review=67,StarReview=new(7),Description= new()
                {
                    ManHinh="1242 x 2688 Pixels 6.5 inch",Camera="Triple 12MP Ultra Wide",Pin="Lâu hơn Iphone Xs Max 5h",RAM="4 GB",CPU="Apple A13 Bionic",
                    HĐH="IOS 13"
                } },
                    new SanPham() { ProductName = "IPhone 11 Pro Max 512GB",Image="/assets/anhIphone.png", Discount = 2000000, Sale = 1565000, Price = 43990000,Review=69,StarReview = new(7),Description= new()
                {
                    ManHinh="1242 x 2688 Pixels 6.5 inch",Camera="Triple 12MP Ultra Wide",Pin="Lâu hơn Iphone Xs Max 5h",RAM="4 GB",CPU="Apple A13 Bionic",
                    HĐH="IOS 13"
                } },
                    new SanPham() { ProductName = "IPhone 11 Pro Max 64GB",Image="/assets/anhIphone.png", Discount = 1500000, Sale = 1653000, Price = 33990000,Review=59,StarReview = new(7),Description= new()
                {
                    ManHinh="1125 x 2436 Pixels 5.8 inch",Camera="Triple 12MP Ultra Wide",Pin="Lâu hơn Iphone Xs 4h",RAM="4 GB",CPU="Apple A13 Bionic",
                    HĐH="IOS 13"
                } }
                }
            };
            return View(CacNoiDung);
        }
    }
}
