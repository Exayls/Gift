using Gift.Domain.UIModel.Border;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder
    {
		public IUIElementBuilder WithText(string text);
		public IUIElementBuilder WithBorder(IBorder border);
    }
}
