using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public abstract class UIElementBuilder : IBuilder<UIElement>
    {
        public abstract UIElementBuilder WithBorder(IBorder border);
        public abstract UIElementBuilder WithBorder(string borderStr, IBorderMapper mapper);

        public abstract UIElementBuilder WithBackgroundColor(Color color);
        public abstract UIElementBuilder WithBackgroundColor(string colorStr, IColorMapper mapper);

        public abstract UIElementBuilder WithForegroundColor(Color color);
        public abstract UIElementBuilder WithForegroundColor(string colorStr, IColorMapper mapper);

        public abstract UIElementBuilder WithId(string id);

        public abstract UIElement Build();
    }
}
