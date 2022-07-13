using System.ComponentModel.DataAnnotations;

namespace manager.Dtos
{
    public class ProductCreateUpdateDto
    {
        public string Details { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }
    }
}
