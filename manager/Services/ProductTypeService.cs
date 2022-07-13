using manager.Context;
using manager.Dtos;
using manager.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manager.Services
{
    public class ProductTypeService
    {
        private readonly MyDbContext _context;
        public ProductTypeService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public ProductTypeDto Create(ProductTypeCreateUpdateDto productType)
        {
            var product = productType.Adapt<ProductType>();

            _context.ProductType.Add(product);

            _context.SaveChanges();

            return product.Adapt<ProductTypeDto>();
        }

        public List<ProductTypeDto> Get()
        {
            return _context.ProductType.AsNoTracking()
                .Include(productType => productType.Products).ProjectToType<ProductTypeDto>().ToList();
        }

        public ProductTypeDto GetById(int id)
        {
            var productType = _context.ProductType.SingleOrDefault(productType => productType.Id == id);

            if (productType is null)
                throw new Exception("Not found");

            return productType.Adapt<ProductTypeDto>();

        }

        public ProductType Put(int id, ProductTypeCreateUpdateDto editedType)
        {
            var productType = _context.ProductType.SingleOrDefault(productType => productType.Id == id);

            if (productType is null)
                throw new Exception("Not found");

            editedType.Adapt(productType);
            productType.Name = editedType.Name;

            _context.SaveChanges();

            return productType.Adapt<ProductType>();
        }

        public void Delete(int id)
        {
            var productType = _context.ProductType.SingleOrDefault(productType => productType.Id == id);

            if (productType is null)
                throw new Exception("Not found");
            _context.Remove(productType);
            _context.SaveChanges();
        }

    }
}
