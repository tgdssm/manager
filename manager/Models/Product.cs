using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manager.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Details { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public List<ProductSize> ProductSizes { get; set; }

    }
}
