using BmesRestApi.Models.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace BmesRestApi.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private Database.BmesDbContext _bmesDbContext;
        public ProductRepository(Database.BmesDbContext bmesDbContextService)
        {
            _bmesDbContext = bmesDbContextService;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var product = _bmesDbContext.Products
                .Include(navigationPropertyPath: p => p.Category)
                .Include(navigationPropertyPath: p => p.Brand);
            return product;
        }

        void IProductRepository.DeleteProduct(Product product)
        {
            _bmesDbContext.Products.Remove(product);
            _bmesDbContext.SaveChanges();
        }

        void IProductRepository.EditProduct(Product product)
        {
            _bmesDbContext.Products.Update(product);
            _bmesDbContext.SaveChanges();
        }

        Product IProductRepository.FindProductById(long Id)
        {
           var found = _bmesDbContext.Products.Find(Id);
            return found;
        }

        void IProductRepository.SaveProduct(Product product)
        {
            _bmesDbContext.Products.Add(product);
            _bmesDbContext.SaveChanges();
        }
    }
}
