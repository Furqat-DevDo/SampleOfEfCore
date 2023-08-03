using EfCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ShopDbContext shopDb_context;

        public ValuesController(ShopDbContext shopDb_context)
        {
            this.shopDb_context = shopDb_context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var shops = shopDb_context.Shops.ToList();
            return Ok(shops);
        }
    }
}
