using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.CommandsResults.Orders
{
    public class AddOrderResult
    {
        public int Id { get; set; }
        public AddOrderResult(int ProductId)
        {
            Id = ProductId;
        }
    }
}
