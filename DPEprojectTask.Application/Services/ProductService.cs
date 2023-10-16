using DPEprojectTask.Application.IServices;
using DPEprojectTask.Application.Model;
using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Products;

namespace DPEprojectTask.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddProduct(AddProductModel model)
        {
            var result =new Product(
                0 ,
                model.Title ,
                model.Body ,
                DateTime.Now ,
                model.Price ,
                model.ImagePath ,
                model.FilePath ,
                model.ProductCategoryId ,
                model.IsVisible ,
                false ,
                model.IsSellable
                );
           await _productRepository.add(result);
            return result.Id;
        }
    }
}
