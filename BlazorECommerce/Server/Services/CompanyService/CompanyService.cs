using BlazorECommerce.Server.Services.PaletteService;
using BlazorECommerce.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlazorECommerce.Server.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _context;
        private readonly IPaletteService _paletteService;

        public CompanyService(DataContext context, IPaletteService paletteService)
        {
            _context = context;
            _paletteService = paletteService;
        }

        public async Task<ServiceResponse<Company>> GetCompany()
        {
            var company = await _context.Company
                                        .Include(c => c.ThemePalette)  // Include theme palette details
                                        .FirstOrDefaultAsync();

            return new ServiceResponse<Company>
            {
                Data = company
            };
        }

        public async Task<ServiceResponse<bool>> UpdateCompany(Company company)
        {
            var serviceResponse = new ServiceResponse<bool>();

            var companyToUpdate = await _context.Company
                                                .FirstOrDefaultAsync(x => x.Id == company.Id);
            if (companyToUpdate == null)
            {
                companyToUpdate = new Company()
                {
                    Id = company.Id,
                    Name = company.Name,
                    ThemePaletteId = company.ThemePaletteId,
                    ThemePalette = await _paletteService.GetPalette(company.ThemePaletteId)
                };

                await _context.Company.AddAsync(companyToUpdate);
                await _context.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Success = true;

                return serviceResponse;
            } else
            {
                companyToUpdate.Name = company.Name;
                companyToUpdate.ThemePaletteId = company.ThemePaletteId;

                await _context.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Success = true;

                return serviceResponse;
            }

            

            
        }
    }
}
