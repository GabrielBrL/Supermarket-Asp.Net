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
    public class EditProductsUseCase : IEditProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public EditProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Execute(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}
