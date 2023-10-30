using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder<T> : IBuilder<T>
           where T : UIElement
    {
        public IUIElementBuilder<T> WithBorder(IBorder border);
    }
}
