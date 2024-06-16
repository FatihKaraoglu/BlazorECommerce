using BlazorECommerce.Server.Services.PaletteService;
using BlazorECommerce.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemePaletteController : ControllerBase
    {
        private readonly IPaletteService _paletteService;

        public ThemePaletteController(IPaletteService paletteService)
        {
            _paletteService = paletteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThemePalette>>> GetPalettes()
        {
            return Ok(await _paletteService.GetPalettes());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> AddPalette(ThemePalette newPalette)
        {
            var response = new ServiceResponse<bool>();
            var addedPalette = await _paletteService.AddPalette(newPalette);
            if(addedPalette != null)
            {
                response.Success = true;
            } else
            {
                response.Success = false;
                response.Message = "Error while trying to add new Palette!";
            }
            return Ok(addedPalette);
        }
    }
}
