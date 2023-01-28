using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class VStack : Container
    {
        public VStack()
        {
        }

        public void AddChild(UIElement uIElement)
        {
            Childs.Add(uIElement);
            int GlobalPosition = Context?.GlobalPosition?.y ?? 0;
            int ChildContextPosition = GlobalPosition;
            foreach (UIElement renderable in Childs)
            {
                ChildContextPosition += renderable.Context?.Bounds?.Height ?? 0;
            }
            dynamic element = uIElement;
            setChildContext(element, ChildContextPosition);
        }

        private void setChildContext(Label UiElement, int ChildContextPosition)
        {
            if (Context == null)
            {
                throw new ArgumentNullException();
            }
            if (UiElement.IsExplicit())
            {
                if (Context.GlobalPosition == null)
                {
                    throw new ArgumentNullException();
                }
                UiElement.setContext(Context.GlobalPosition, new Bound(0, Context?.Bounds?.Width ?? 0));
            }
            else
            {
                UiElement.setContext(new Position(ChildContextPosition, Context?.GlobalPosition?.x ?? 0), new Bound(1, Context?.Bounds?.Width ?? 0));
            }
        }
    }
}