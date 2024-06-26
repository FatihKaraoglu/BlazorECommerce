﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorECommerce.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool Featured { get; set; } = false;

        public List<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();
    }
}
