using System;

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
    }
}
