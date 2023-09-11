using InventoryService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQSystem;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IBookService _bookService;
    
        public InventoryController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("order-status")]
        public async Task<IActionResult> OrderStatus()
        {
            var statusResponse = await _bookService.InventoryStatusAsync();

            if (statusResponse == null)
            {
                return Ok("No message received");
            }
            return Ok("New order message received");
        }


        [HttpGet]
        public async Task<IActionResult> GetInventories()
        {
            var inventoriess = await _bookService.GetInventoriesAsync();
            if (inventoriess == null)
            {
                return NoContent();
            }
            return Ok(inventoriess);
        }


        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            var order = _bookService.GetInventoryByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
