using AutoMapper;
using OrderService.Core.Entities;
using OrderService.Infrastructure.Models.Requests;
using OrderService.Infrastructure.Models.Responses;

namespace OrderService.Infrastructure.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderResponse, Order>().ReverseMap();
        }
    }
}
