using manager.Context;
using manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace manager.Services
{
    public class ProductService
    {
        private readonly MyDbContext _context;
        public ProductService([FromServices] MyDbContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {


            _context.Product.Add(product);

            _context.SaveChanges();

            return product;
        }

        public List<Product> Get()
        {
            return _context.Product.ToList();
        }

        public Product GetById(int id)
        {
            var product = _context.Product.SingleOrDefault(product => product.Id == id);

            if (product is null)
                throw new Exception("Not found");

            return product;

        }

        public Product Put(int id, Product editedProduct)
        {
            var product = _context.Product.SingleOrDefault(product => product.Id == id);

            if (product is null)
                throw new Exception("Not found");

            //copio as atualizações
            product.Price = product.Price;
            product.Details = product.Details;

            _context.SaveChanges();

            return product;
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
