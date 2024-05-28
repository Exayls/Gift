using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public interface IUIElementBuilder : IBuilder<UIElement>
    {
        public IUIElementBuilder WithBorder(IBorder border);
        public IUIElementBuilder WithBorder(string borderStr, IBorderMapper mapper);

        public IUIElementBuilder WithBackgroundColor(Color color);
        public IUIElementBuilder WithBackgroundColor(string colorStr, IColorMapper mapper);

        public IUIElementBuilder WithForegroundColor(Color color);
        public IUIElementBuilder WithForegroundColor(string colorStr, IColorMapper mapper);

        public IUIElementBuilder WithId(string id);
    }
}
