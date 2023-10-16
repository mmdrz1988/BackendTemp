using DPEprojectTask.Domain.Commands.Orders;
using DPEprojectTask.Domain.DomainEvent.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Orders
{

    public class Order : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        private readonly List<OrderItem> _orderItems;

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(int id, int userId , DateTime createdAt)
            : this()
        {
            Id = id;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public void AddItem(List<OrderItemCommand> cmdorderItems)
        {
            foreach (var item in cmdorderItems)
            {
                _orderItems.Add(new OrderItem(0,Id,item.ProductId,item.Price));
                //todo:
                AddDomainEvent(new OrderAddedEvent(UserId));

            }
        }
    }
}
