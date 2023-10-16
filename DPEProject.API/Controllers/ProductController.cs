using DPEprojectTask.Application.Contracts;
using DPEprojectTask.Domain.Commands.Products;
using DPEPTask.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPEProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        IAddProductCommandFactory _addProductCommandFactory;

        public ProductController(IMediator mediator , IAddProductCommandFactory addProductCommandFactory)
        {
            _mediator = mediator;
            _addProductCommandFactory = addProductCommandFactory;    
        }

        [HttpPost,Route("[action]")]
        public async Task<IActionResult> AddProduct([FromForm]AddProductCommandModel addProductCommandModel)
        {
            var command =await _addProductCommandFactory.CreateAsync(addProductCommandModel);
            //todo: save file    
            //todo: create AddProductCommand    
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut, Route("[action]")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);
            return Ok(result);
        }


        [HttpDelete, Route("[action]")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand deleteProductCommand)
        {
            var result = await _mediator.Send(deleteProductCommand);
            return Ok(result);
        }
    }
}
