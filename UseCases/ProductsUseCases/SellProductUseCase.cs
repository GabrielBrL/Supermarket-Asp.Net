using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _transactionRepository;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase transactionRepository)
        {
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
        }
        public void Execute(string cashierName, int? qty, int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product != null)
            {                
                _transactionRepository.Execute(cashierName, productId, qty.Value);
                product.Quantity -= qty;
                _productRepository.UpdateProduct(product);
            }
        }
    }
}
