using Gift.UI.MetaData;

namespace Gift.UI.Interface
{
    public interface IUIElement : Renderable
    {
        Context Context { get; set; }
        IBorder Border { get; set; }
    }
}