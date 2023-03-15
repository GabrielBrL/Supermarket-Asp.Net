using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext _marketContext;
        public CategoryRepository(MarketContext context)
        {
            _marketContext = context;
        }

        public void AddCategory(Category category)
        {
            _marketContext.Categories.Add(category);
            _marketContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _marketContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            if (category != null)
            {
                _marketContext.Remove(category);
                _marketContext.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _marketContext.Categories.ToList();
        }

        public Category GetCategoriesByCategoryId(int categoryId)
        {
            return _marketContext.Categories.SingleOrDefault(c => c.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = _marketContext.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.Description = category.Description;
            }
            _marketContext.SaveChanges();
        }
    }
}
