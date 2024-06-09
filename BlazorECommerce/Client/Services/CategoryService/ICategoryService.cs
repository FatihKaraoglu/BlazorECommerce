namespace BlazorECommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        List<Category> FeaturedCategories { get; set; }

        Task GetCategories();
        Task GetFeaturedCategories();
    }
}
