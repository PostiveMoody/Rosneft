using System.Runtime.Serialization;

namespace Rosneft.Domain.Exceptions
{
    [Serializable]
    public class AlreadyChangedException : Exception
    {
        public AlreadyChangedException()
        {
        }

        public AlreadyChangedException(string message) : base(message)
        {
        }

        public AlreadyChangedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
