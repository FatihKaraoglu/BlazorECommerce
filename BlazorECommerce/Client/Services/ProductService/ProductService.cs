﻿using BlazorECommerce.Client.Pages;
using BlazorECommerce.Shared;
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
            ServiceResponse<List<Product>> result = null;
            try
            {
                result = categoryUrl == null ?
                    await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured") :
                    await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            }
            catch (Exception ex)
            {
                Message = $"An error occurred: {ex.Message}";
                ProductsChanged?.Invoke();
                return;
            }

            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }
            else
            {
                Products = new List<Product>();
                Message = "No Products found";
            }

            CurrentPage = 1;
            PageCount = 0;

            ProductsChanged?.Invoke();
        }

        public async Task GetFeaturedProducts()
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
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

        public async Task GetMostViewedProducts()
        {
            var result =
              await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/most-viewed");
            if (result != null && result.Data != null)
            {
                Products = result.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Count == 0)
            {
                Message = "No Products found";
            }

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<List<Product>>> GetRangeOfProducts(List<int> productIds)
        {
            var response = await _http.PostAsJsonAsync("api/product/GetRangeOfProducts", productIds);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            return result;
            
        }


        async Task<ServiceResponse<List<Product>>> IProductService.GetFilteredProducts(ProductFilterCriteria criteria)
        {
            var response = await _http.PostAsJsonAsync("api/product/filtered-products", criteria);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Product>>>();

            return result;
        }
    }   
}
