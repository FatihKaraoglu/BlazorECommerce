﻿using BlazorECommerce.Server.Data;
using BlazorECommerce.Shared;

namespace BlazorECommerce.Server.Services.CategoryService
{
    
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>> 
            { 
                Data = categories 
            };
        }

        public async Task<ServiceResponse<List<Category>>> GetFeaturedCategories()
        {
            var categories = await _context.Categories.Where(x => x.Featured == true)
                .Take(5)
                .ToListAsync();
            return new ServiceResponse<List<Category>> { Data = categories };
        }
    }
}
