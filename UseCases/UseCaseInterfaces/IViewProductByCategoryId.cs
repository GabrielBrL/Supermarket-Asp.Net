using CoreBusiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}