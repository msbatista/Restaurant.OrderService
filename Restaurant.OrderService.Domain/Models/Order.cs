using System;
using System.Collections.Generic;

namespace Restaurant.OrderService.Domain
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public long AddressId { get; set; }
        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
        public bool IsQuit { get; set; }
        public virtual Address Address { get; set; }
    }
}
