using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manager.Models
{
    [Table("ProductSize")]
    public class ProductSize
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Size { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }


    }
}
