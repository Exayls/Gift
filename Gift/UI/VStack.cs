using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    /// <summary>
    /// element container that stack them vertically
    /// </summary>
    public class VStack: Container
    {
        public VStack()
        {
        }

        public void AddChild(UIElement uIElement)
        {
            Childs.Add(uIElement);
            int GlobalPositionLastChild = 0;
            if (Childs.Count != 0)
            {
                GlobalPositionLastChild = Context?.GlobalPosition?.y?? 0;
            }
            uIElement.setContext(new Position(GlobalPositionLastChild, Context?.GlobalPosition?.x?? 0), new Bound(0, Context?.Bounds?.Width ?? 0));
        }
    }
}