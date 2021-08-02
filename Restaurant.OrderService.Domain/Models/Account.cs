using Restaurant.OrderService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.OrderService.Domain
{
    public class Account : IAccount
    {
        public long Id { get; }
        public DateTime CreationDate { get; }
        public virtual IReadOnlyList<Order> Orders { get; } = new List<Order>();

        public Account() { }

        public Account(long id, DateTime creationDate, IReadOnlyList<Order> orders)
        {
            Id = id;
            CreationDate = creationDate;
            Orders = orders;
        }

        public double AccountDebit
        {
            get
            {
                double total = 0;

                return Orders.ToList().Aggregate(total, (current, order) =>
                {
                    if (!order.IsQuit)
                    {
                        return current + order.TotalOrder;
                    }
                    else
                    {
                        return 0;
                    }
                });
            }
        }

        public bool HasDebits()
        {
            return AccountDebit != 0;
        }

        public void AddOrder(Order order)
        {
            Orders.ToList().Add(order);
        }
    }
}
