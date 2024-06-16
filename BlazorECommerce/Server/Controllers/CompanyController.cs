using BlazorECommerce.Server.Services.CompanyService;
using BlazorECommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IAuthService _authService;


        public CompanyController(ICompanyService companyService, IAuthService authService)
        {
            _companyService = companyService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Company>>> GetCompany()
        {
            var result = await _companyService.GetCompany();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> SetCompany(Company company)
        {
           var result = await _companyService.UpdateCompany(company);
            return Ok(result);
        }
    }
}
