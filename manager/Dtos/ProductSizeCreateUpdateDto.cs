using System.ComponentModel.DataAnnotations;

namespace manager.Dtos
{
    public class ProductSizeCreateUpdateDto
    {

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Size { get; set; }

        public int ProductId { get; set; }
    }
}
