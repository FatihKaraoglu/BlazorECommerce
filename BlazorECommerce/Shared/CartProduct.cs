using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ProductVariant> Variants { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }


    }
}
