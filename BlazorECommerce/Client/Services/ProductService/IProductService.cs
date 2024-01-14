using BlazorECommerce.Shared;

namespace BlazorECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        public List<Product> Products { get; set; }
        public string Message { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProduct(int productId);
        Task SearchProducts(string searchText, int page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
