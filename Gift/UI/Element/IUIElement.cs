using Gift.UI.Border;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public interface IUIElement : Renderable
    {
        Context Context { get; set; }
        IBorder Border { get; set; }
    }
}