using System.ComponentModel.DataAnnotations;

namespace InventoryService.Infrastructure.Models.Requests
{
    public class BookRequest
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage ="Book's title characters is between 2 and 100", MinimumLength = 2)]
        public string BookName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
