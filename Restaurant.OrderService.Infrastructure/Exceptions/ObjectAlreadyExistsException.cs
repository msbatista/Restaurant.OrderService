using System;
using System.Runtime.Serialization;

namespace Restaurant.OrderService.Infrastructure.Exceptions
{
    [Serializable]
    public class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException()
        {
        }

        public ObjectAlreadyExistsException(string message) : base(message)
        {
        }

        public ObjectAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ObjectAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
