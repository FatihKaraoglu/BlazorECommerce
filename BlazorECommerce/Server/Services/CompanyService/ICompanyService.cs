using BlazorECommerce.Shared;

namespace BlazorECommerce.Server.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<ServiceResponse<Company>> GetCompany();
        Task<ServiceResponse<bool>> UpdateCompany(Company company);
    }
}
