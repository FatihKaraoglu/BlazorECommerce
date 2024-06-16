using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorECommerce.Client.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _http;

        public CompanyService(HttpClient http)
        {
            _http = http;
        }

        public Company Company { get; set; } = new Company();

        public async Task GetCompany()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Company>>("api/company");
            if (response != null && response.Data != null)
            {
                Company  = response.Data;
            }
        }
    }
}
