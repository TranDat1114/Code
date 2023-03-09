using Microsoft.AspNetCore.Mvc;

namespace Lab_4_1_2_Net_4.Controllers
{
    public class HomeController: Controller
    {

        //Các Route cho Index kiến thức liên quan đến ATTRIBUTE ROUTES
        [Route("/")]
        [Route("Home")]
        [Route("Home/Index")]
        [Route("MyHome")]
        [Route("MyHome/FriendlyName")]
        public string Index()
        {
            return "Index() Action Method of StudentController";
        }

        //Ràng buộc id là int(Buộc là số nguyên: sử dụng cách inline cách này gọn lẹ) và là optional(Có thể có hoặc không)
        [Route("Home/Details/{id:int?}")]
        public string Details(string id)
        {
            return @$"Details() Action Method of StudentController and {id}";
        }
    }
}
