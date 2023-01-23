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
            int nbChilds = Childs.Count;
            if (Childs.Count > 1)
            {
                GlobalPositionLastChild = Childs[nbChilds - 2].Context?.GlobalPosition?.y ?? 0;
                ChildContextPosition = GlobalPositionLastChild + Childs[nbChilds - 2].Context?.Bounds?.Height ?? 0;
            }
            dynamic element = uIElement;
            setChildContext(element, ChildContextPosition);
        }

        private void setChildContext(Label uIElement, int ChildContextPosition)
        {
            uIElement.setContext(new Position(ChildContextPosition, Context?.GlobalPosition?.x ?? 0), new Bound(1, Context?.Bounds?.Width ?? 0));
        }
    }
}