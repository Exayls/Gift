using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public interface IContainerBuilder : IUIElementBuilder, IBuilder<Container>
    {
        public IContainerBuilder WithBound(Size bound);
        public IContainerBuilder WithBound(string boundStr, IBoundMapper mapper);

        public IContainerBuilder WithHeight(int height);
        public IContainerBuilder WithHeight(string heightStr);

        public IContainerBuilder WithWidth(int width);
        public IContainerBuilder WithWidth(string widthStr);

        public IContainerBuilder WithSelectableElement(UIElement element);
        public IContainerBuilder WithUnSelectableElement(UIElement element);

        public IContainerBuilder IsSelectableContainer(bool isSelectableContainer);
        public IContainerBuilder IsSelectableContainer(string isSelectableContainer, IBooleanMapper boolMapper);
    }
}
