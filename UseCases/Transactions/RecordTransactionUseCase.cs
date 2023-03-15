using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.Transactions
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGetProductByIdUseCase _productRepository;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase productRepository)
        {
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
        }

        public void Execute(string cashierName, int productId, int qty)
        {
            var product = _productRepository.Execute(productId);
            _transactionRepository.Save(cashierName, productId, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}
