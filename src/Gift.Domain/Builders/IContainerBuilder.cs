using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IContainerBuilder<T> : IBuilder<T>
           where T : UIElement
    {
        public IContainerBuilder<T> WithBorder(IBorder border);
        public IContainerBuilder<T> WithBound(Bound bound);
    }
}
