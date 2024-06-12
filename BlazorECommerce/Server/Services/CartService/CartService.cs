using BlazorECommerce.Server.Data;
using BlazorECommerce.Shared;
using BlazorECommerce.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorECommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _dataContext;
        private readonly IAuthService _authService;

        public CartService(DataContext dataContext, IAuthService authService)
        {
            _dataContext = dataContext;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartProduct>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProduct>>
            {
                Data = new List<CartProduct>()
            };

            foreach (var item in cartItems)
            {
                var product = await _dataContext.Products
                    .Where(x => x.Id == item.ProductId)
                    .FirstOrDefaultAsync();
                if (product == null)
                {
                    continue;
                }

                var productVariants = await _dataContext.ProductVariants
                    .Where(x => x.ProductId == item.ProductId)
                    .Include(x => x.ProductType)
                    .ToListAsync();

                if (productVariants == null || productVariants.Count == 0)
                {
                    continue;
                }

                var cartProduct = new CartProduct
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Variants = productVariants,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }
            return result;
        }


        public async Task<ServiceResponse<List<CartProduct>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _dataContext.CartItems.AddRange(cartItems);
            await _dataContext.SaveChangesAsync();

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = (await _dataContext.CartItems.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count;
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartProduct>>> GetDbCartProducts(int? userId = null)
        {
            if(userId == null)
                userId = _authService.GetUserId();
            return await GetCartProducts(await _dataContext.CartItems
                .Where(ci => ci.UserId == userId).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _dataContext.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                    ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                _dataContext.CartItems.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbcartItem = await _dataContext.CartItems
                 .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                     ci.ProductTypeId == cartItem.ProductTypeId && ci.UserId == _authService.GetUserId());
            if (dbcartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Cart Item does not exist",
                    Success = false,
                };
            }

            dbcartItem.Quantity = cartItem.Quantity;
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };

        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var dbcartItem = await _dataContext.CartItems
                 .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
                     ci.ProductTypeId == productTypeId && ci.UserId == _authService.GetUserId());
            if (dbcartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "Cart Item does not exist",
                    Success = false,
                };
            }

            _dataContext.CartItems.Remove(dbcartItem);
            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
