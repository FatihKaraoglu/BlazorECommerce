using BlazorECommerce.Client.Themes;
using MudBlazor;

namespace BlazorECommerce.Client.Services.ThemeService
{
    public interface IThemeService
    {
        ITheme GetTheme(string themeName);
        public MudTheme theme { get; set; }

    }
}
