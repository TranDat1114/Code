using Microsoft.AspNetCore.Mvc;

namespace Lab_4_4_Net_4.Controllers
{
    public class HomeController : Controller
    {

        //Câu c
        // [Route("/")]
        // [Route("Home")]
        // [Route("Home/Index")]
        // [Route(@"Home/Index/{year:regex(^\d{{4}}$)?}")]
        public string Index(int year)
        {
            return $@"Year = {year}";
        }
    }
}
