using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryInMemoryRepository()
        {
            _categories = new List<Category>()
            {
                
            };
        }

        public void AddCategory(Category category)
        {
            if (_categories.Any(v => v.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if(_categories.Count > 0)
            {
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId++;
            }
            else
            {
                category.CategoryId = 1;
            }
            _categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var categoryDeleted = GetCategoriesByCategoryId(categoryId);
            if (categoryDeleted != null)
            {
                _categories.Remove(categoryDeleted);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoriesByCategoryId(int categoryId)
        {
            return _categories?.SingleOrDefault(v => v.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryEditable = GetCategoriesByCategoryId(category.CategoryId);
            if (categoryEditable != null)
            {
                categoryEditable.Name = category.Name;
                categoryEditable.Description = category.Description;
            }
        }
    }
}