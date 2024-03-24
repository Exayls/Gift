using System;

namespace Gift.Repository
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
