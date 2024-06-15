using BlazorECommerce.Shared;
using BlazorECommerce.Shared.DTO;

namespace BlazorECommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponse<ProductSearchResultDTO>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
        Task<ServiceResponse<List<Product>>> GetMostViewed();
        Task IncreaseViewCount(int productId);
        Task<ServiceResponse<List<Product>>> GetRangeOfProducts(List<int> productIds);
        Task<ServiceResponse<List<Product>>> GetFilteredProducts(ProductFilterCriteria filterCriteria);


    }
}
