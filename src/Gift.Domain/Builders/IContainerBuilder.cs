using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IContainerBuilder<T> : IUIElementBuilder<T>
           where T : UIElement
    {
        public IContainerBuilder<T> WithBound(Bound bound);
    }
}
