using manager.Context;
using manager.Dtos;
using manager.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manager.Services
{
    public class ProductService
    {
        private readonly MyDbContext _context;
        public ProductService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public ProductDto Create(ProductCreateUpdateDto newProduct)
        {

            var product = newProduct.Adapt<Product>();
            _context.Product.Add(product);

            _context.SaveChanges();

            return product.Adapt<ProductDto>();
        }

        public List<ProductDto> Get()
        {
            return _context.Product.AsNoTracking()
                .Include(product => product.ProductType)
                .Include(product => product.ProductSizes)
                .ProjectToType<ProductDto>()
                .ToList();
        }

        public ProductDto GetById(int id)
        {
            var product = _context.Product.AsNoTracking()
                .Include(product => product.ProductType)
                .Include(product => product.ProductSizes)
                .SingleOrDefault(product => product.Id == id);

            if (product is null)
                throw new Exception("Not found");

            return product.Adapt<ProductDto>();

        }

        public ProductDto Put(int id, ProductCreateUpdateDto editedProduct)
        {
            var product = _context.Product.SingleOrDefault(product => product.Id == id);

            if (product is null)
                throw new Exception("Not found");



            editedProduct.Adapt(product);

            _context.SaveChanges();

            return product.Adapt<ProductDto>();
        }

        public void Delete(int id)
        {
            var product = _context.Product.SingleOrDefault(product => product.Id == id);

            if (product is null)
                throw new Exception("Not found");
            _context.Remove(product);
            _context.SaveChanges();
        }

    }
}
