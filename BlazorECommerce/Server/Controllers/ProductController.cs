using BlazorECommerce.Server.Data;
using BlazorECommerce.Server.Services.ProductService;
using BlazorECommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet] 
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProdcut() 
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }


        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProdcut(int productId)
        {
            var result = await _productService.GetProductAsync(productId);
            return Ok(result);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProdcutByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }


    }
}
