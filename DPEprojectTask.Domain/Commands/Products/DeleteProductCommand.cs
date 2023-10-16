using DPEprojectTask.Domain.CommandsResults.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Commands.Products
{
    public class DeleteProductCommand : IRequest<DeleteProductResult>
    {
        public int Id { get; set; }

    }
}
