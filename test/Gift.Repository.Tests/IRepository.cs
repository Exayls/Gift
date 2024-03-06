using System.Collections.Generic;
using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Tests
{
    internal interface IRepository
    {
        IEnumerable<Container> GetContainers();
        UIElement GetRoot();
        void SaveRoot(UIElement root);
    }
}
