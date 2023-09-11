using System.ComponentModel.DataAnnotations;

namespace OrderService.Infrastructure.Models.Requests
{
    public class OrderRequest
    {
        [Required]
        [StringLength(maximumLength:100, ErrorMessage ="Book's Name characters is between 2 to 100", MinimumLength =2)]
        public string BookName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Range(0,100000, ErrorMessage ="Book's quantity can't be more than 100000")]
        public int Quantity { get; set; }
    }
}
