using manager.Models;
using System.ComponentModel.DataAnnotations;
namespace manager.Dtos
{
    public class ProductSizeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Size { get; set; }
        
        public Product Product { get; set; }

        public int ProductId { get; set; }
    }
}
