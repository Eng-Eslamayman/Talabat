using System.ComponentModel.DataAnnotations;

namespace Talabat.BusinessLayer.DTOs
{
    public class OrderDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
