using System.Collections.Generic;
using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Tests
{
    internal interface IRepository
    {
        void SaveRoot(UIElement root);
        UIElement GetRoot();

        IEnumerable<Container> GetContainers();
        IEnumerable<Container> GetSelectableContainers();

    }
}
