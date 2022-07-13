using System.ComponentModel.DataAnnotations;

namespace manager.Dtos
{
    public class ProductTypeCreateUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
