using DPEprojectTask.Domain.Commands.Orders;
using DPEprojectTask.Domain.DomainEvent.Orders;
using DPEprojectTask.Domain.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPETasks.Domain.UnitTest.Models
{
    public class OrderTest
    {
        [Fact]
        public void Should_HaveDomainEvent_WhenAnOrderItemIsAdded()
        {
            var order = new Order(0, 3, DateTime.Now);

            var orderItem = new List<OrderItemCommand>()
                {
                     new OrderItemCommand()
                     {
                         Id = 1,
                         OrderId = order.Id,
                         Price =150,
                         ProductId=3
                     }
                };
            order.AddItem(orderItem);
            var expected = typeof(OrderAddedEvent);
            var domainEvent = order.DomainEvents.First();

            var actual = domainEvent.GetType();

            Assert.Equal(expected, actual);
        }
    }
}
