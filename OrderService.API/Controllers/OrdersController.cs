using Microsoft.AspNetCore.Mvc;
using OrderService.Infrastructure.Models.Requests;
using OrderService.Services.Interfaces;
using RabbitMQSystem;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;
        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var oders = await _orderService.GetOrdersAsync();
            if (oders == null)
            {
                return NoContent();
            }

            return Ok(oders);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _orderService.CreateOrderAsync(orderRequest);
            return Ok();
        }


        /*[HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrder(int orderId, OrderRequest orderRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updateOrderId = _orderService.GetOrderByIdAsync(orderId);
            
            if(updateOrderId == null)
            {
                return NotFound();
            }
            await _orderService.UpdateOrderAsync(orderId, orderRequest);
            _messagePublisher.SendMessage(orderRequest);
            return Ok();
        }


        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var orderToDelete = _orderService.GetOrderByIdAsync(orderId);

            if (orderToDelete == null)
            {
                return NotFound();
            }

            _messagePublisher.SendMessage($"Order with OrderId {orderId} has been deleted");
            return NoContent();
        }*/
    }
}
