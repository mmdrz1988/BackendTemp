
using DPEprojectTask.Domain.Commands.Products;
using Microsoft.AspNetCore.Http;

namespace DPEPTask.Core.ViewModels
{
    public class AddProductCommandModel : AddProductCommand
    {
        public IFormFile File { get; set; }

    }

}
 