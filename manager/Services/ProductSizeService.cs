using manager.Context;
using manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace manager.Services
{
    public class ProductSizeService
    {
        private readonly MyDbContext _context;
        public ProductSizeService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public ProductSize Create(ProductSize productSize)
        {


            _context.ProductSize.Add(productSize);

            _context.SaveChanges();

            return productSize;
        }

        public List<ProductSize> Get()
        {
            return _context.ProductSize.ToList();
        }

        public ProductSize GetById(int id)
        {
            var productSize = _context.ProductSize.SingleOrDefault(productSize => productSize.Id == id);

            if (productSize is null)
                throw new Exception("Not found");

            return productSize;

        }

        public ProductSize Put(int id, ProductSize editedSize)
        {
            var productSize = _context.ProductSize.SingleOrDefault(productSize => productSize.Id == id);

            if (productSize is null)
                throw new Exception("Not found");

            //copio as atualizações
            productSize.Size = editedSize.Size;

            _context.SaveChanges();

            return productSize;
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
