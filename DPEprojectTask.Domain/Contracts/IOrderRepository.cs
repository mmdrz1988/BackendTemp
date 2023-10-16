using DPEprojectTask.Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Contracts
{
    public interface IOrderRepository
    {
        Task Save(Order order);
    }
}
