using InventoryService.Infrastructure.Models.Responses;

namespace InventoryService.Services.Interfaces
{
    public interface IBookService
    {
        Task<string> InventoryStatusAsync();
        Task<IEnumerable<BookResponse>> GetInventoriesAsync();
        Task<BookResponse> GetInventoryByIdAsync(int Id);
        Task DeleteInventoryAsync(int Id);
    }
}
