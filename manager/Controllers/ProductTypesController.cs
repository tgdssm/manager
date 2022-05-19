using Microsoft.AspNetCore.Mvc;
using manager.Models;
using manager.Services;

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
        public ActionResult<ProductType> GetProductType()
        {
            var productTypes = _service.Get();

            return Ok(productTypes);
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        public ActionResult<ProductType> GetProductType(int id)
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
        public ActionResult PutProductType(int id, ProductType editedType)
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
        public ActionResult<ProductType> PostProductType([FromBody] ProductType newProductType)
        {
            var productType = _service.Create(newProductType);
            return CreatedAtAction("GetProductType", new { id = productType.Id }, productType);
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
