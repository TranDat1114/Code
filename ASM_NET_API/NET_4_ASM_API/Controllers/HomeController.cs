using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using NET_4_ASM_API.Models;

namespace NET_4_ASM_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController: Controller
    {
        private readonly ShopBanCamContext _dbContext;

        public HomeController(ShopBanCamContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet(Name = "GetCatagories")]
        public async Task<List<Category>> GetCatagories()
        {
            return await _dbContext.Categories.ToListAsync();

        }
    }
}
