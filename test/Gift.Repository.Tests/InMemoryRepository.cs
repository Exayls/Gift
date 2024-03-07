using System.Collections.Generic;
using System.Linq;
using Gift.Domain.Builders;
using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Tests
{
    public class InMemoryRepository : IRepository
    {
        private UIElement _root;

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

        private IList<Container> ResearchContainers(UIElement element)
        {
            var containers = new List<Container>();
            if (element is Container)
            {
                containers.Add((Container)element);
                foreach (UIElement child in ((Container)element).Childs)
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
    }
}
