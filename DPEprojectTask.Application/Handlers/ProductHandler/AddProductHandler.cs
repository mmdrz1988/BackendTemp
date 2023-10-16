using DPEprojectTask.Domain.CommandsResults.Products;
using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Handlers.ProductHandler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResult>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<AddProductResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var result = new Product(
               0,
               request.Title,
               request.Body,
               DateTime.Now,
               request.Price,
               request.ImagePath,
               request.FilePath,
               request.ProductCategoryId,
               request.IsVisible,
               false,
               request.IsSellable
               );
            await _productRepository.add(result);
            return new AddProductResult(result.Id);
        }
    }
}
