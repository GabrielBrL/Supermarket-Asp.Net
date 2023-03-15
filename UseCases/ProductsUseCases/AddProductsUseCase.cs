using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class AddProductsUseCase : IAddProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(Product product)
        {
            _productRepository.AddProduct(product);
        }
    }
}
