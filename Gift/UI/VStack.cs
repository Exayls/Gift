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
            int y = 0;
            if (Childs.Count != 0)
            {
                y = Context?.GlobalPosition?.y?? 0;
            }
            uIElement.Renderer = Renderer;
            uIElement.setContext(new Position(y, Context?.GlobalPosition?.x?? 0), new Bound(0, Context?.Bounds?.Width ?? 0));
        }
    }
}