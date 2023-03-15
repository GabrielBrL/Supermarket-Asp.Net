namespace UseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int? qty, int productId);
    }
}