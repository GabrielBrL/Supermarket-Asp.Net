using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> _products { get; set; }
        public ProductInMemoryRepository()
        {
            _products = new List<Product>()
            {
                
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProductById(int id)
        {
            return _products?.SingleOrDefault(p => p.ProductId == id);
        }        

        public void AddProduct(Product product)
        {
            if (_products.Any(p => p.Name == product.Name)) return;
            if (_products.Count > 0)
            {
                int maxId = _products.Max(p => p.ProductId) + 1;
                product.ProductId = maxId;
            }
            else
            {
                product.ProductId = 1;
            }
            _products.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            var productUpdated = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productUpdated != null)
            {               
                productUpdated.Name = product.Name;
                productUpdated.CategoryId = product.CategoryId;
                productUpdated.Quantity = product.Quantity;
                productUpdated.Price = product.Price;
                productUpdated.CategoryId = product.CategoryId;
            }
        }
        public void DeleteProduct(int id)
        {
            var productDeleted = _products.SingleOrDefault(p => p.ProductId == id);
            if (productDeleted == null) return;
            _products.Remove(productDeleted);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId);
        }
    }
}
