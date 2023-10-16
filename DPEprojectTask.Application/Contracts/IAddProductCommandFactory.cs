using DPEprojectTask.Domain.Commands.Products;
using DPEPTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Contracts
{
    public interface IAddProductCommandFactory
    {
        Task<AddProductCommand> CreateAsync(AddProductCommandModel model);
    }
}
