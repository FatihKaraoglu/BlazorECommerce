using BlazorECommerce.Shared;
using System.Reflection.Metadata.Ecma335;

namespace BlazorECommerce.Server.Services.PaletteService
{
    public interface IPaletteService
    {
        public Task<List<ThemePalette>> GetPalettes();
        public Task<ThemePalette> GetPalette(int paletteId);
        Task<ThemePalette> AddPalette(ThemePalette newPalette);
    }
}
