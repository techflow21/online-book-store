namespace InventoryService.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderedDate { get; set; }
    }
}
