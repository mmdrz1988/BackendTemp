using DPEprojectTask.Domain.Commands.Orders;
using DPEprojectTask.Domain.CommandsResults.Orders;
using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Orders;
using DPEprojectTask.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.Handlers.OrderHandler
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, AddOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<AddOrderResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(0, 1, DateTime.Now);
            order.AddItem(request.orderItems);
            await _orderRepository.Save(order);
            return new AddOrderResult(order.Id);
        }
    }
}
