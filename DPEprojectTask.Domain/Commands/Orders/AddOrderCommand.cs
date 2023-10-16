using DPEprojectTask.Domain.CommandsResults.Orders;
using MediatR;

namespace DPEprojectTask.Domain.Commands.Orders
{
    public class AddOrderCommand : IRequest<AddOrderResult>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<OrderItemCommand> orderItems { get; set; }
    }
    public class OrderItemCommand
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}
