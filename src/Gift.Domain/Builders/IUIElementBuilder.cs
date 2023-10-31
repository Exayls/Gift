using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder<T> : IBuilder<T>
           where T : UIElement
    {
        public IUIElementBuilder<T> WithBorder(IBorder border);
        public IUIElementBuilder<T> WithBackgroundColor(Color color);
        public IUIElementBuilder<T> WithForegroundColor(Color color);
    }
}
