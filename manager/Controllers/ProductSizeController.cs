using Microsoft.AspNetCore.Mvc;
using manager.Models;
using manager.Services;
using manager.Dtos;

namespace manager.Controllers
{
    [Route("api/product_sizes")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {
        private readonly ProductSizeService _service;

        public ProductSizeController([FromServices] ProductSizeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ProductSizeDto>> GetProductSizes()
        {
            var productSizes = _service.Get();

            return Ok(productSizes);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductSizeDto> GetProductSize(int id)
        {
            try
            {
                var productSize = _service.GetById(id);
                return Ok(productSize);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ProductSizeDto> PutProductSize(int id, ProductSizeCreateUpdateDto editedSize)
        {
            try
            {
                var productSize = _service.Put(id, editedSize);
                return Ok(productSize);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<ProductSizeDto> PostProductSize([FromBody] ProductSizeCreateUpdateDto newProductSize)
        {
            var productSize = _service.Create(newProductSize);
            return CreatedAtAction(nameof(GetProductSize), new { id = productSize.Id }, productSize);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductSize(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
