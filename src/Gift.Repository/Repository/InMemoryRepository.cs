using System;
using System.Collections.Generic;
using System.Linq;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Repository
{
    public class InMemoryRepository : IRepository
    {
        private UIElement _root;
        private Container? _selectedContainer;

        public InMemoryRepository()
        {
            _root = new LabelBuilder().WithText("no root saved").Build();
        }

        public UIElement GetRoot()
        {
            return _root;
        }

        public void SaveRoot(UIElement root)
        {
            _root = root;
        }

        public IEnumerable<Container> GetContainers()
        {
            var containers = ResearchContainers(_root);
            return containers.AsEnumerable();
        }

        private static List<Container> ResearchContainers(UIElement element)
        {
            var containers = new List<Container>();
            if (element is Container container)
            {
                containers.Add(container);
                foreach (UIElement child in container.Childs)
                {
                    containers.AddRange(ResearchContainers(child));
                }
            }
            return containers;
        }

        public IEnumerable<Container> GetSelectableContainers()
        {
            return GetContainers().Where(container => container.IsSelectableContainer);
        }

        public Container? GetSelectedContainer()
        {
            if (_selectedContainer != null && GetSelectableContainers().Contains(_selectedContainer))
            {
                return _selectedContainer;
            }
            IEnumerable<Container> selectableContainers = GetSelectableContainers();
            if (selectableContainers.Any())
            {
                return selectableContainers.First();
            }
            return null;
        }

        public void SelectContainer(Container container)
        {
            if (!container.IsSelectableContainer)
            {
                throw new UnSelectableContainerException($"container {container} is not selectable");
            }
            if (!GetSelectableContainers().Contains(container))
            {
                throw new ElementNotInHierarchyException($"container {container} is not part of root");
            }
            _selectedContainer = container;
        }

        public Container? GetParent(Container element)
        {
            bool selectParent(UIElement currentElement)
            {
                if (currentElement is Container container)
                {
                    if (container.Childs.Contains(element))
                        return true;
                }
                return false;
            }

            return (Container?)SelectFirst(_root, selectParent);
        }

        private static UIElement? SelectFirst(UIElement element, Func<UIElement, bool> func)
        {
            if (func(element))
            {
                return element;
            }
            if (element is Container container)
                foreach (var child in container.Childs)
                {
                    return SelectFirst(child, func);
                }
            return null;
        }

        public UIElement? GetFromId(string v)
        {
            bool selectId(UIElement currentElement)
            {
                return currentElement.Id == v;
            }

            return SelectFirst(_root, selectId);
        }
    }
}
