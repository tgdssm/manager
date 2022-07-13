using manager.Context;
using manager.Dtos;
using manager.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace manager.Services
{
    public class ProductSizeService
    {
        private readonly MyDbContext _context;
        public ProductSizeService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public ProductSizeDto Create(ProductSizeCreateUpdateDto newProductSize)
        {
            var productSize = newProductSize.Adapt<ProductSize>();

            _context.ProductSize.Add(productSize);

            _context.SaveChanges();

            return productSize.Adapt<ProductSizeDto>();
        }

        public List<ProductSizeDto> Get()
        {
            return _context.ProductSize.AsNoTracking()
                .Include(productSize => productSize.Product)
                .ProjectToType<ProductSizeDto>()
                .ToList();
        }

        public ProductSizeDto GetById(int id)
        {
            var productSize = _context.ProductSize
                .AsNoTracking()
                .Include(productSize => productSize.Product)
                .ProjectToType<ProductSizeDto>()
                .SingleOrDefault(productSize => productSize.Id == id);

            if (productSize is null)
                throw new Exception("Not found");

            return productSize.Adapt<ProductSizeDto>();

        }

        public ProductSizeDto Put(int id, ProductSizeCreateUpdateDto editedSize)
        {
            var productSize = _context.ProductSize
                .SingleOrDefault(productSize => productSize.Id == id);

            if (productSize is null)
                throw new Exception("Not found");

            //copio as atualizações
            editedSize.Adapt(productSize);
            _context.SaveChanges();

            return productSize.Adapt<ProductSizeDto>();
        }

        public void Delete(int id)
        {
            var productSize = _context.ProductSize.SingleOrDefault(productSize => productSize.Id == id);

            if (productSize is null)
                throw new Exception("Not found");
            _context.Remove(productSize);
            _context.SaveChanges();
        }

    }
}
