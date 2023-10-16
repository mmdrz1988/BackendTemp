using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.CommandsResults.Products;
using DPEprojectTask.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Handlers.ProductHandler
{
    public class UpdateProductCommandHandler : MediatR.IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {

        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.get(request.Id);
            product.update(request);
            await _productRepository.Save(product);
            return new UpdateProductResult(product.Id);
        }
    }
}
