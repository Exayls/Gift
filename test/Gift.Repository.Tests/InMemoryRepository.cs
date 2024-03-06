using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Tests
{
    public class InMemoryRepository : IRepository
    {
        private UIElement _root;

        public InMemoryRepository()
        {
        }

        public UIElement GetRoot()
        {
			return _root;
        }

        public void SaveRoot(UIElement root)
        {
            throw new System.NotImplementedException();
        }
    }
}
