using Microsoft.AspNetCore.Mvc;
using manager.Models;
using manager.Services;
using manager.Dtos;

namespace manager.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController([FromServices] ProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<ProductDto> GetProducts()
        {
            var product = _service.Get();

            return Ok(product);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            try
            {
                var product = _service.GetById(id);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult<ProductDto> PutProduct(int id, ProductCreateUpdateDto editedProduct)
        {
            try
            {
                var product = _service.Put(id, editedProduct);
                return Ok(product);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<ProductDto> PostProduct([FromBody] ProductCreateUpdateDto newProduct)
        {
            var product = _service.Create(newProduct);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
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
