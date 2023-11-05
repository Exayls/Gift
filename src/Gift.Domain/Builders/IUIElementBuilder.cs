using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder : IBuilder<UIElement>
    {
        public IUIElementBuilder WithBorder(IBorder border);
        public IUIElementBuilder WithBackgroundColor(Color color);
        public IUIElementBuilder WithForegroundColor(Color color);
    }
}
