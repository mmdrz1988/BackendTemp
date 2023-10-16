using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Orders;
using DPEprojectTask.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Save(Order order)
        {
             _appDbContext.orders.Update(order);
            await _appDbContext.SaveEntityAsync();
        }
    }
}
