using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; } = string.Empty;
        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
