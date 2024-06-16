using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ThemePaletteId { get; set; }
        public ThemePalette? ThemePalette { get; set; }
    }
}
