using BlazorECommerce.Shared;
using BlazorECommerce.Shared.DTO;

namespace BlazorECommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProduct>>> GetCartProducts(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartProduct>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponse<int>> GetCartItemsCount();
        Task<ServiceResponse<List<CartProduct>>> GetDbCartProducts(int? userId =  null);
        Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId);
        Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);





    }
}
