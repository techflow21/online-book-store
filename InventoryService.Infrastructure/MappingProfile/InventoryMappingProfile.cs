using AutoMapper;
using InventoryService.Core.Entities;
using InventoryService.Infrastructure.Models.Responses;

namespace InventoryService.Infrastructure.MappingProfile
{
    public class InventoryMappingProfile : Profile
    {
        public InventoryMappingProfile()
        {
            CreateMap<Book, BookResponse>().ReverseMap();
        }
    }
}
