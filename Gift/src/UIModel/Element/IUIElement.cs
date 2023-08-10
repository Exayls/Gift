namespace Gift.UI.Element
{
    public interface IUIElement : IRenderable
    {
        bool IsSelectedElement { get; set; }
        bool IsInSelectedContainer { get; set; }
    }
}
