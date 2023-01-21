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
            int GlobalPositionLastChild = Context?.GlobalPosition?.y ?? 0;
            int ChildContextPosition = GlobalPositionLastChild;
            if (Childs.Count == 2)
            {
                GlobalPositionLastChild = Childs[0].Context?.GlobalPosition?.y ?? 0;
                ChildContextPosition = GlobalPositionLastChild + Childs[0].Context?.Bounds?.Height??0;
            }
            uIElement.setContext(new Position(ChildContextPosition, Context?.GlobalPosition?.x?? 0), new Bound(1, Context?.Bounds?.Width ?? 0));
        }
    }
}