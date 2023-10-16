using DPEprojectTask.Application.Contracts;
using DPEprojectTask.Domain.Commands.Products;
using DPEPTask.Core.ViewModels;
using DPETasks.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Factories
{
    public class AddProductCommandFactory: IAddProductCommandFactory
    {
        private readonly IProductImageService _productImageService;
          
        public AddProductCommandFactory(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<AddProductCommand> CreateAsync(AddProductCommandModel addProductCommandModel)
        {
            if (addProductCommandModel.File is null)
                throw new ArgumentNullException(nameof(addProductCommandModel));

            var ImagePath =await _productImageService.SaveImageAsync(addProductCommandModel.File);
            addProductCommandModel.ImagePath = ImagePath; 
            return new AddProductCommand(addProductCommandModel);
        }
    }
}
