using DPEprojectTask.Domain.DomainEvent.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain
{
    public class Entity
    {
        public List<INotification> DomainEvents;
        public Entity()
        {
            DomainEvents = new List<INotification>();
        }
        public void AddDomainEvent(INotification @event)
        {
            DomainEvents.Add(@event);
        }
        public void CleanDomainEvent()
        {
            DomainEvents.Clear();
        }
    }
}
