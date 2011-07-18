namespace ReflectionUtilites.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class ReflectionException : Exception
    {
        public ReflectionException()
        {
        }

        public ReflectionException(string message)
            : base(message)
        {
        }

        public ReflectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ReflectionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}