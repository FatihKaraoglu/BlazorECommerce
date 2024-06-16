using BlazorECommerce.Shared;

namespace BlazorECommerce.Server.Services.PaletteService
{
    public class PaletteService : IPaletteService
    {
        private readonly DataContext _dataContext;

        public PaletteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ThemePalette>> GetPalettes()
        {
           var palettes = await _dataContext.Palettes.ToListAsync();
           return palettes;
        }

        public async Task<ThemePalette> AddPalette(ThemePalette newPalette)
        {
            _dataContext.Palettes.Add(newPalette);
            await _dataContext.SaveChangesAsync();
            return newPalette;
        }

        public async Task<ThemePalette> GetPalette(int paletteId)
        {
            var palettes = await _dataContext.Palettes.Where(x => x.Id == paletteId).FirstOrDefaultAsync();
            return palettes;
        }
    }
}
