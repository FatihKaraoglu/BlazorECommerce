using Azure;
using BlazorECommerce.Server.Data;
using BlazorECommerce.Shared;
using BlazorECommerce.Shared.DTO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace BlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                .Where(p => p.Featured).Include(p => p.Variants).ToListAsync()
            };
            return response; 
        }

        public async Task<ServiceResponse<List<Product>>> GetMostViewed()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                .OrderByDescending(p => p.Views)
                .Take(10)
                .Include(p => p.Variants).ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
           var response = new ServiceResponse<Product>();
            var product = await _context.Products
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .FirstOrDefaultAsync(p => p.Id == productId);
            if(product == null)
            {
                response.Success = false;
                response.Message = "This Product does not exist!";
            } else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>();

            // Find the category by URL
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Url.ToLower() == categoryUrl.ToLower());

            if (category != null)
            {
                // Retrieve all products associated with the found category
                var products = await _context.ProductCategories
                    .Where(pc => pc.CategoryId == category.Id)
                    .Include(pc => pc.Product)
                        .ThenInclude(p => p.Variants) // Include variants here
                    .Select(pc => pc.Product) // Select the products after including the variants
                    .ToListAsync();

                response.Data = products;
            }
            else
            {
                response.Success = false;
                response.Message = "Category not found.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
           var products = await FindProductBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description != null)
                {
                    var punctuation = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuation));

                    foreach (var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) 
                            && !result.Contains(word)){
                            result.Add(word);
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<List<Product>>> GetRangeOfProducts(List<int> productIds)
        {
            var response = new ServiceResponse<List<Product>>();

            // Retrieve the list of products that match the provided product IDs
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .Include(p => p.Variants)
                .ThenInclude(v => v.ProductType)
                .ToListAsync();

            // Check if any products were found
            if (products == null || !products.Any())
            {
                response.Success = false;
                response.Message = "None of the products exist!";
            }
            else
            {
                response.Data = products;
            }

            return response;
        }

        public async Task IncreaseViewCount(int productId)
        {
            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            product.Views++;
            _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResults);

            var products = await _context.Products.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .Skip((page - 1) * (int) pageResults)
                            .Take((int) pageResults)
                            .ToListAsync();

            var response = new ServiceResponse<ProductSearchResultDTO>
            {
                Data = new ProductSearchResultDTO
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int) pageCount
                }

            };

            return response;
        }

        private Task<List<Product>> FindProductBySearchText(string searchText)
        {
            return _context.Products.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
                            || p.Description.ToLower().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .ToListAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetFilteredProducts(ProductFilterCriteria filterCriteria)
        {
            var response = new ServiceResponse<List<Product>>();
            var query = _context.Products.Include(p => p.Variants).Include(p => p.ProductCategories).ThenInclude(pc => pc.Category).AsQueryable();

            if (!string.IsNullOrEmpty(filterCriteria.Category))
            {
                query = query.Where(p => p.ProductCategories.Any(pc => pc.Category.Name == filterCriteria.Category));
            }

            if (!string.IsNullOrEmpty(filterCriteria.Format))
            {
                query = query.Where(p => p.Variants.Any(x => x.ProductType.Name == filterCriteria.Format));
            }

            if (filterCriteria.MinPrice.HasValue)
            {
                query = query.Where(p => p.Variants.Any(x => x.Price >= filterCriteria.MinPrice.Value) );
            }

            if (filterCriteria.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Variants.Any(x => x.Price <= filterCriteria.MaxPrice.Value));
            }

            //if (filterCriteria.MinReview.HasValue)
            //{
            //    query = query.Where(p => p.Review >= filterCriteria.MinReview.Value);
            //}

            //if (filterCriteria.MaxReview.HasValue)
            //{
            //    query = query.Where(p => p.Review <= filterCriteria.MaxReview.Value);
            //}

            response.Data = await query.ToListAsync();
            return response;
        }
    }
}
