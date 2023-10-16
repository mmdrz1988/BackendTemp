using DPEprojectTask.Domain.Commands.Products;
using DPEprojectTask.Domain.CommandsResults.Products;
using DPEprojectTask.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Handlers.ProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResult>
    {

        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
                _productRepository = productRepository;
        }

        public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.get(request.Id);
            product.Delete();
            await _productRepository.Save(product);
            return new DeleteProductResult(product.Id);
        }


    }
}
