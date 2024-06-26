﻿using System.Net.Http.Json;

namespace BlazorECommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Category> FeaturedCategories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (response != null && response.Data != null)
            {
                Categories = response.Data;
            }
        }

        public async Task GetFeaturedCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category/featured");
            if (response != null && response.Data != null)
            {
                FeaturedCategories = response.Data;
            }
            else
            {
                FeaturedCategories = new List<Category>(); // Ensure it's not null
            }
        }
    }
}
