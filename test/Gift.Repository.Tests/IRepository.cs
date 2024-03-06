using Gift.Domain.UIModel.Element;

namespace Gift.Repository.Tests
{
    internal interface IRepository
    {
        UIElement GetRoot();
        void SaveRoot(UIElement root);
    }
}
