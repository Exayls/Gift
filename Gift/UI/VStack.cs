using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
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
            uIElement.Renderer = Renderer;
            uIElement.setContext(new Position(GlobalPositionLastChild, Context?.GlobalPosition?.x?? 0), new Bound(0, Context?.Bounds?.Width ?? 0));
        }
    }
}