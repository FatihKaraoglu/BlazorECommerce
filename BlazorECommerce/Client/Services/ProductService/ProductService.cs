using BlazorECommerce.Shared;
using System.Net.Http.Json;

namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            ProductsChanged.Invoke();
        }
    }   
}
