using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;
namespace BmesRestApi.Repositories
{
    public interface ICategoryRepository
    {
        Category FindCategoryById(long Id);
        IEnumerable<Category> GetAllCategory();
        void DeleteCategory(Category category);
        void SaveCategory(Category category);
        void EditCategory(Category category);
    }
}
