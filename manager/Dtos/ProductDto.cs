using manager.Models;
using System.ComponentModel.DataAnnotations;
namespace manager.Dtos
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public List<ProductSize> ProductSizes { get; set; }
    }
}
