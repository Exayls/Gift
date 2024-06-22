using System;

namespace Gift.Repository.Repository
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
