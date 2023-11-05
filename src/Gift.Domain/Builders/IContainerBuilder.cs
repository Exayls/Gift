using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IContainerBuilder : IUIElementBuilder, IBuilder<Container>
    {
        public IContainerBuilder WithBound(Bound bound);
    }
}
