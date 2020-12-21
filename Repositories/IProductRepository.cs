using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories
{
    public interface IProductRepository
    {
        Product FindProductById(long Id);
        IEnumerable<Product> GetAllProducts();
        void DeleteProduct(Product product);
        void SaveProduct(Product product);
        void EditProduct(Product product);
    }
}
