using System;

namespace Gift.Repository.Repository
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
