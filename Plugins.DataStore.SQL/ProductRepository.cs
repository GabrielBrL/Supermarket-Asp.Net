using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext _marketContext;

        public ProductRepository(MarketContext marketContext)
        {
            _marketContext = marketContext;
        }

        public void AddProduct(Product product)
        {
            _marketContext.Products.Add(product);
            _marketContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _marketContext.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _marketContext.Products.Remove(product);
                _marketContext.SaveChanges();
            }

        }

        public Product GetProductById(int productId)
        {
            return _marketContext.Products.SingleOrDefault(p => p.ProductId == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _marketContext.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _marketContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _marketContext.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if(prod != null)
            {
                prod.Name = product.Name;
                prod.CategoryId = product.CategoryId;
                prod.Price = product.Price;
                prod.Quantity = product.Quantity;
                _marketContext.SaveChanges();
            }
        }
    }
}
