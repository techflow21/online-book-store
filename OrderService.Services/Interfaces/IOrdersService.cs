using OrderService.Infrastructure.Models.Requests;
using OrderService.Infrastructure.Models.Responses;

namespace OrderService.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderResponse>> GetOrdersAsync();
        Task CreateOrderAsync(OrderRequest orderRequest);
    }
}
