using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderService.Core.Entities;
using OrderService.Infrastructure.DataContext;
using OrderService.Infrastructure.Models.Requests;
using OrderService.Infrastructure.Models.Responses;
using OrderService.Services.Interfaces;
using RabbitMQSystem;

namespace OrderService.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageManager _messagePublisher;

        public OrdersService(OrderDbContext context, IMapper mapper, IMessageManager messagePublisher)
        {
            _context = context;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();

            if (orders == null)
            {
                return Enumerable.Empty<OrderResponse>();
            }
            var response = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return response;
        }


        public async Task CreateOrderAsync(OrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                throw new ArgumentNullException(nameof(orderRequest));
            }

            var newOrder = _mapper.Map<Order>(orderRequest);
            newOrder.OrderedDate = DateTime.Now;

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            _messagePublisher.SendMessage(newOrder);
        }
    }
}
