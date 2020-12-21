using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories
{
    public interface IBrandRepository
    {
        Brand FindBrandById(long Id);
        IEnumerable<Brand> GetAllBrand();
        void DeleteBrand(Brand brand);
        void SaveBrand(Brand brand);
        void EditBrand(Brand brand);
    }
}
