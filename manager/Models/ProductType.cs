using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manager.Models
{
    [Table("ProductType")]
    public class ProductType
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
