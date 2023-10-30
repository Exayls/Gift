using Gift.Domain.UIModel.Element;

namespace Gift.Domain.Builders
{
    public interface IUIElementBuilder<T> : IBuilder<T>
           where T : UIElement
    {
    }
}
