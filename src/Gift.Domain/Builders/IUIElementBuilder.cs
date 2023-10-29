using Gift.Domain.UIModel.Border;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder<TBuilder, TProduct>
    where TBuilder : IUIElementBuilder<TBuilder, TProduct>
    {
        public TBuilder WithBorder(IBorder border);
        public TProduct Build();
    }
}
