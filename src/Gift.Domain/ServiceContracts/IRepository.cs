using System.Collections.Generic;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.ServiceContracts
{
    public interface IRepository
    {
        void SaveRoot(UIElement root);
        UIElement GetRoot();

        IEnumerable<Container> GetContainers();
        IEnumerable<Container> GetSelectableContainers();

        void SelectContainer(Container container);
        Container? GetSelectedContainer();
        Container? GetParent(Container element);
        UIElement? GetFromId(string v);
    }
}
