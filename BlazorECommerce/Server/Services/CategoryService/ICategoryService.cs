using BlazorECommerce.Shared;

namespace BlazorECommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategories();
        Task<ServiceResponse<List<Category>>> GetFeaturedCategories();
    }
}
