using System;
using System.Runtime.Serialization;

namespace Projekt
{
    [Serializable]
    public class BledneDaneException : Exception
    {
        public BledneDaneException()
        {
        }

        public BledneDaneException(string message) : base(message)
        {
        }

        public BledneDaneException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BledneDaneException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}