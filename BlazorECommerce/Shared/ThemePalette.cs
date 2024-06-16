using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class ThemePalette
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string? PrimaryColorLighten { get; set; }
        public string? PrimaryColorDarken { get; set; }
        public string? SecondaryColor { get; set; }
        public string? SecondaryColorLighten { get; set; }
        public string? SecondaryColorDarken { get; set; }
        public string? TertiaryColor { get; set; }
        public string? TertiaryLighten { get; set; }
        public string? TertiaryDarken { get; set; }
        public string? Info { get; set; }
        public string? Success { get; set; }
        public string? Warning { get; set; }
        public string? Error { get; set; }
        public string? Dark { get; set; }
    }
}
