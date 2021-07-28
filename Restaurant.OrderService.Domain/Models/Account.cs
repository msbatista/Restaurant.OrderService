using System;
using System.Collections.Generic;

namespace Restaurant.OrderService.Domain
{
    public class Account
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
