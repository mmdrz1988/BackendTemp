using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.Model.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }

        public OrderItem(int id, int orderId, int productId, decimal price)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            
        }
    }
}
