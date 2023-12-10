using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IContainerBuilder : IUIElementBuilder, IBuilder<Container>
    {
        public IContainerBuilder WithBound(Bound bound);
        public IContainerBuilder WithBound(string boundStr, IBoundMapper mapper);
        public IContainerBuilder WithSelectableElement(UIElement element);
    }
}
