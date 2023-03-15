using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class DeleteProductsUseCase : IDeleteProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
