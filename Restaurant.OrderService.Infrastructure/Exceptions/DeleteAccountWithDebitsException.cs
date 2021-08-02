using System;
using System.Runtime.Serialization;

namespace Restaurant.OrderService.Infrastructure.Exceptions
{
    public class DeleteAccountWithDebitsException : Exception
    {
        public DeleteAccountWithDebitsException()
        {
        }

        public DeleteAccountWithDebitsException(string message) : base(message)
        {
        }

        public DeleteAccountWithDebitsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteAccountWithDebitsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
