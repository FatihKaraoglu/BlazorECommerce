﻿using BlazorECommerce.Shared;
using BlazorECommerce.Shared.DTO;
using System.Net.Http.Json;

namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public ProductService(HttpClient http)
        {
            _http = http;
        }
        private readonly HttpClient _http;
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products ...";

        public int CurrentPage { get; set; } = 1;

        public int PageCount { get; set; } = 0;

        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if(Products.Count == 0)
            {
                Message = "No Products found";
            }

            ProductsChanged.Invoke();
        }

        public async Task SearchProducts(string searchText, int page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResultDTO>>($"api/product/search/{searchText}/{page}");
            if(result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
                LastSearchText = searchText;

            }

            if(Products.Count == 0)
            {
                Message = "No Products found.";
            }

            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }
    }   
}
