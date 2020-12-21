using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories.Implementations
{
    
    public class BrandRepository : IBrandRepository
    {
        private Database.BmesDbContext _bmesDbContext;
        public BrandRepository(Database.BmesDbContext bmesDbContextServer)
        {
            _bmesDbContext = bmesDbContextServer;
        }
        public void DeleteBrand(Brand brand)
        {
            _bmesDbContext.Brands.Remove(brand);
            _bmesDbContext.SaveChanges();
        }

        public void EditBrand(Brand brand)
        {

            _bmesDbContext.Brands.Update(brand);
            _bmesDbContext.SaveChanges();
        }

        public Brand FindBrandById(long Id)
        {
           var found = _bmesDbContext.Brands.Find(Id);
            return found;
        }

        public  IEnumerable<Brand> GetAllBrand()
        {
            var brand =  _bmesDbContext.Brands;
            return brand;
        }

        public void SaveBrand(Brand brand)
        {
            _bmesDbContext.Brands.Add(brand);
            _bmesDbContext.SaveChanges();
        }
    }
}
