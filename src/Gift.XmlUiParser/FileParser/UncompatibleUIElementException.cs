using System;
using System.Runtime.Serialization;

namespace Gift.XmlUiParser.FileParser
{
    internal class UncompatibleUIElementException : Exception
    {
        public UncompatibleUIElementException()
        {
        }

        public UncompatibleUIElementException(string? message) : base(message)
        {
        }

        public UncompatibleUIElementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UncompatibleUIElementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
