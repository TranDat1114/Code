using Lab_5_2_Net_4.Models;

using Microsoft.AspNetCore.Mvc;

namespace Lab_5_2_Net_4.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Student Details Page";
            ViewData["Header"] = "Student Details";
            List<Student> students = new()
            {
                new()
                {
                    StudentId = Guid.NewGuid(),
                    Name= "Trần Phú Đạt",
                    Brand="Ho Chi Minh",
                    Section="Cong vien phan mem"
                },
                new()
                {
                    StudentId = Guid.NewGuid(),
                    Name= "Trần Hoàng",
                    Brand="Ha Noi",
                    Section="Cau Giay"
                },
                new()
                {
                    StudentId = Guid.NewGuid(),
                    Name= "Ngọt Ngào",
                    Brand="Phu Yen",
                    Section="Tuy Hoa"
                }
            };

            ViewData["Students"] = students;

            return View();
        }
    }
}
