using System;
using System.Runtime.Serialization;

namespace Restaurant.OrderService.Domain.Execptions
{
    [Serializable]
    public class OrderIsQuittedDomainException : Exception
    {
        public OrderIsQuittedDomainException()
        {
        }

        public OrderIsQuittedDomainException(string message) : base(message)
        {
        }

        public OrderIsQuittedDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderIsQuittedDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
