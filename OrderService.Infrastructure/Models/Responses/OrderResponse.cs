
namespace OrderService.Infrastructure.Models.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderedDate { get; set; }
    }
}
