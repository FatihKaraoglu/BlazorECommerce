using BlazorECommerce.Shared.DTO;

namespace BlazorECommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task GetCartProducts();
        Task RemoveProductFromCart(int productId, int prodcutTypeId);
        Task UpdateQuantity(CartProduct product);
        Task StoreCartItems(bool emptyLocalCart);
        Task GetCartItemsCount();
        public List<CartProduct> CartProducts { get; set; }
    }
}
