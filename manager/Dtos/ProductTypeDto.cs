using manager.Models;
using System.ComponentModel.DataAnnotations;

namespace manager.Dtos
{
    public class ProductTypeDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
