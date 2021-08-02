using Restaurant.OrderService.Domain.Execptions;
using Restaurant.OrderService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.OrderService.Domain
{
    public class Order : IOrder
    {
        public long Id { get; }
        public DateTime TransactionDate { get; }
        public long AddressId { get; }
        public virtual IReadOnlyList<Product> Products { get; } = new List<Product>();
        public virtual Address Address { get; set; }
        public bool IsQuit;

        public double TotalOrder
        {
            get
            {
                double total = 0;

                return Products.ToList().Aggregate(total, (current, product) =>
                {
                    return current + product.Price;
                });
            }
        }

        public Order() { }

        public Order(long id, DateTime transactionDate, long addressId, IReadOnlyList<Product> products, bool isQuit, Address address)
        {
            Id = id;
            TransactionDate = transactionDate;
            AddressId = addressId;
            Products = products;
            IsQuit = isQuit;
            Address = address;
        }

        public void QuitOrder(bool quitOrder)
        {
            IsQuit = quitOrder;
        }

        public bool IsOrderQuitted()
        {
            return IsQuit;
        }

        public void AddProduct(Product product)
        {
            if (IsQuit)
            {
                throw new OrderIsQuittedDomainException("Order is closed!");
            }

            Products.ToList().Add(product);
        }
    }
}
