using manager.Context;
using manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace manager.Services
{
    public class ProductTypeService
    {
        private readonly MyDbContext _context;
        public ProductTypeService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public ProductType Create(ProductType productType)
        {


            _context.ProductType.Add(productType);

            _context.SaveChanges();

            return productType;
        }

        public List<ProductType> Get()
        {
            return _context.ProductType.ToList();
        }

        public ProductType GetById(int id)
        {
            var productType = _context.ProductType.SingleOrDefault(productType => productType.Id == id);

            if (productType is null)
                throw new Exception("Not found");

            return productType;

        }

        public ProductType Put(int id, ProductType editedType)
        {
            var productType = _context.ProductType.SingleOrDefault(productType => productType.Id == id);

            if (productType is null)
                throw new Exception("Not found");

            //copio as atualizações
            productType.Name = editedType.Name;

            _context.SaveChanges();

            return productType;
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
