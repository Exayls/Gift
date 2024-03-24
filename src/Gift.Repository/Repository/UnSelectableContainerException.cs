using System;

namespace Gift.Repository
{
    [Serializable]
    public class UnSelectableContainerException : Exception
    {
        public UnSelectableContainerException()
        {
        }

        public UnSelectableContainerException(string? message) : base(message)
        {
        }

    }
}
