using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class ProductFilterCriteria
    {
        public string? Category { get; set; }
        public string? Author { get; set; }
        public string? Format { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinReview { get; set; }
        public int? MaxReview { get; set; }
    }
}
