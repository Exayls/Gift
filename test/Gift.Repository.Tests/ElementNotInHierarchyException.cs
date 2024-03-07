using System;

namespace Gift.Repository.Tests
{
    [Serializable]
    public class ElementNotInHierarchyException : Exception
    {
        public ElementNotInHierarchyException()
        {
        }

        public ElementNotInHierarchyException(string? message) : base(message)
        {
        }
    }
}
