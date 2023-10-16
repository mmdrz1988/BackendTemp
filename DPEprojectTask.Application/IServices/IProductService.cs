using DPEprojectTask.Application.Model;

namespace DPEprojectTask.Application.IServices
{
    public interface IProductService
    {

        Task<int> AddProduct(AddProductModel model);
    }
}
