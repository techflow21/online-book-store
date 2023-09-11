using AutoMapper;
using InventoryService.Core.Entities;
using InventoryService.Infrastructure.DataContext;
using InventoryService.Infrastructure.Models.Responses;
using InventoryService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQSystem;

namespace InventoryService.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly InventoryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMessageManager _messageSubscriber;
        public BookService(InventoryDbContext context, IMapper mapper, IMessageManager messageSubscriber)
        {
            _context = context;
            _mapper = mapper;
            _messageSubscriber = messageSubscriber;
        }

        public async Task<string> InventoryStatusAsync()
        {
            // Receive a message from RabbitMQ
            var message = _messageSubscriber.ReceiveMessage();
            if (string.IsNullOrEmpty(message))
            {
                return "No order received.";
            }

            // Deserialize the JSON message into a Book object
            var order = JsonConvert.DeserializeObject<Book>(message);

            // Process and save the order
            await _context.Books.AddAsync(order);
            await _context.SaveChangesAsync();

            return "Order received, processed and saved to database.";
        }


        public async Task<IEnumerable<BookResponse>> GetInventoriesAsync()
        {
            var inventories = await _context.Books.ToListAsync();

            if (inventories == null)
            {
                return Enumerable.Empty<BookResponse>();
            }
            var response = _mapper.Map<IEnumerable<BookResponse>>(inventories);
            return response;
        }


        public async Task<BookResponse> GetInventoryByIdAsync(int id)
        {
            var book = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();

            if (book == null)
            {
                throw new ArgumentNullException();
            }
            var response = _mapper.Map<BookResponse>(book);
            return response;
        }


        public async Task DeleteInventoryAsync(int id)
        {
            var inventoryToDelete = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            _context.Books.Remove(inventoryToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
