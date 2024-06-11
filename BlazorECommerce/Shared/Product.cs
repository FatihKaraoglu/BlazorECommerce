using BlazorECommerce.Shared.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Featured { get; set; } = false;
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public List<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();
        public int Views { get; set; } = 0;

        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
    }
}
