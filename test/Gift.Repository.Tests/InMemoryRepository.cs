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
            if (_root is Container)
            {
                var containers = new List<Container>() { (Container)_root }.AsEnumerable();
                return containers;
            }
            return Enumerable.Empty<Container>();
        }
    }
}
