using BlazorECommerce.Shared;

namespace BlazorECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        public List<Product> Products { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
    }
}
