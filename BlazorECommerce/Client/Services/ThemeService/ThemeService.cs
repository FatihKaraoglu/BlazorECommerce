using BlazorECommerce.Client.Themes;
using MudBlazor;

namespace BlazorECommerce.Client.Services.ThemeService
{
    public class ThemeService : IThemeService
    {
        public MudTheme theme { get; set; }

        public ITheme GetTheme(string themeName)
        {
            switch (themeName)
            {
                case "Azur":
                    return new AzurTheme();
                case "Leaf":
                    return new LeafTheme();
                default:
                    return null;

            }
        }
    }
}
