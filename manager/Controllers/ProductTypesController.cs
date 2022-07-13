using Microsoft.AspNetCore.Mvc;
using manager.Models;
using manager.Services;
using manager.Dtos;

namespace manager.Controllers
{
    [Route("api/product_types")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ProductTypeService _service;

        public ProductTypesController([FromServices] ProductTypeService service)
        {
            _service = service;
        }

        // GET: api/ProductTypes
        [HttpGet]
        public ActionResult<List<ProductTypeDto>> GetProductTypes()
        {
            var productTypes = _service.Get();

            return Ok(productTypes);
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        public ActionResult<ProductTypeDto> GetProductType(int id)
        {
            try
            {
                var productType = _service.GetById(id);
                return Ok(productType);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/ProductTypes/5
        [HttpPut("{id}")]
        public ActionResult<ProductTypeDto> PutProductType(int id, ProductTypeCreateUpdateDto editedType)
        {
            try
            {
                var productType = _service.Put(id, editedType);
                return Ok(productType);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: api/ProductTypes
        [HttpPost]
        public ActionResult<ProductTypeDto> PostProductType([FromBody] ProductTypeCreateUpdateDto newProductType)
        {
            var productType = _service.Create(newProductType);
            return CreatedAtAction(nameof(GetProductTypes), new { id = productType.Id }, productType);
        }

        // DELETE: api/ProductTypes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProductType(int id)
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
