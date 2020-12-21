using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BmesRestApi.Models.Product;

namespace BmesRestApi.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private Database.BmesDbContext _bmesDbContext;
        public CategoryRepository(Database.BmesDbContext bmesDbContextService)
        {
            _bmesDbContext = bmesDbContextService;
        }
        public void DeleteCategory(Category category)
        {
            _bmesDbContext.Categories.Remove(category);
            _bmesDbContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _bmesDbContext.Categories.Update(category);
            _bmesDbContext.SaveChanges();
        }

        public Category FindCategoryById(long Id)
        {
            var found = _bmesDbContext.Categories.Find(Id);
            return found;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var category = _bmesDbContext.Categories;
            return category;
        }

        public void SaveCategory(Category category)
        {
            _bmesDbContext.Categories.Add(category);
            _bmesDbContext.SaveChanges();
        }
    }
}
