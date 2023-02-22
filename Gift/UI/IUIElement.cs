using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public interface IUIElement: Renderable
    {
        Context Context { get; set; }
    }
}