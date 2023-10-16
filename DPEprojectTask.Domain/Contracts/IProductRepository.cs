using DPEprojectTask.Domain.Commands;
using DPEprojectTask.Domain.Model.Products;

namespace DPEprojectTask.Domain.Contracts
{
    public interface IProductRepository
    {
        Task add(Product product);
        Task<Product> get(int Id);
        Task Save(Product product);
    }
}
