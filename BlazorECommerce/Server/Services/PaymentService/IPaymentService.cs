using BlazorECommerce.Shared;
using Stripe.Checkout;

namespace BlazorECommerce.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();
        Task<ServiceResponse<bool>> FullfillOrder(HttpRequest request);
    }
}
