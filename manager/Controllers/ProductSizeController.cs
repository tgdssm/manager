using Microsoft.AspNetCore.Mvc;
using manager.Models;
using manager.Services;

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
        public ActionResult<ProductSize> GetProductSizes()
        {
            var productSizes = _service.Get();

            return Ok(productSizes);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductSize> GetProductSize(int id)
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
        public ActionResult PutProductSize(int id, ProductSize editedSize)
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
        public ActionResult<ProductSize> PostProductSize([FromBody] ProductSize newProductSize)
        {
            var productSize = _service.Create(newProductSize);
            return CreatedAtAction("GetProductType", new { id = productSize.Id }, productSize);
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
