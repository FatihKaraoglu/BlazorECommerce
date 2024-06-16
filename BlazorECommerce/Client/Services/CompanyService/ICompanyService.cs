namespace BlazorECommerce.Client.Services.CompanyService
{
    public interface ICompanyService
    {
        public Company Company { get; set; }
        Task GetCompany();
    }
}
