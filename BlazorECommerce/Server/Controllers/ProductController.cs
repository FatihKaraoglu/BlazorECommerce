using BlazorECommerce.Server.Data;
using BlazorECommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] public async Task<ActionResult<List<Product>>> GetProdcut() 
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
