using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.DomainEvent.Orders;
using DPEprojectTask.Domain.Model.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Application.EventHandlers.Orders
{
    public class OrderAddedEventHandler : INotificationHandler<OrderAddedEvent>
    {

        IUserRepository _userrepository;
        public OrderAddedEventHandler(IUserRepository repositoryUser)
        {
            _userrepository = repositoryUser;
        }
        public async Task Handle(OrderAddedEvent notification, CancellationToken cancellationToken)
        {
            CustomIdentityUser user = await _userrepository.Get(notification.UserId);
            user.UpdatePurchasedNumber();
            await _userrepository.Save(user);
        }
    }
}
