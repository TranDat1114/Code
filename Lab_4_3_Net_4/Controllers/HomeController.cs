using Microsoft.AspNetCore.Mvc;

namespace Lab_4_3_Net_4.Controllers
{
    public class HomeController: Controller
    {
        //Câu c
        //Dùng Constraints Attribute Routing
        [Route("/")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Home/Index/{id:int?}")]
        public string Index(int id)
        {
            return $@"I got {id}";
        }
    }
}
