﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEprojectTask.Domain.DomainEvent.Orders
{
    public class OrderAddedEvent : INotification
    {
        public int UserId { get; set; }

        public OrderAddedEvent(int userId)
        {
            UserId = userId;
        }
    }
}
