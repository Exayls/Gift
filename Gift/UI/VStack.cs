using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace Gift.UI
{
    public class VStack : Container
    {
        public override int Height
        {
            get
            {
                int ChildContextPosition = 0;
                foreach (UIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        ChildContextPosition += renderable.Height;
                    }
                }
                return ChildContextPosition;
            }
        }

        public VStack()
        {
        }

        public void AddChild(UIElement uIElement)
        {
            int ChildContextPosition = GetHeightAllChilds();
            Childs.Add(uIElement);
            dynamic element = uIElement;
            setChildContext(element, ChildContextPosition);
        }

        private int GetHeightAllChilds()
        {
            int GlobalPosition = Context?.GlobalPosition?.y ?? 0;
            int ChildContextPosition = GlobalPosition;
            foreach (UIElement renderable in Childs)
            {
                ChildContextPosition += renderable.Context?.Bounds?.Height ?? 0;
            }

            return ChildContextPosition;
        }

        private int GetHeightAllChildsAfter(Renderable uIElement)
        {
            int GlobalPosition = Context?.GlobalPosition?.y ?? 0;
            int ChildContextPosition = GlobalPosition;
            foreach (UIElement renderable in Childs)
            {
                ChildContextPosition += renderable.Context?.Bounds?.Height ?? 0;
                if (renderable == uIElement)
                {
                    return ChildContextPosition;
                }
            }
            return 0;
        }
        public override bool isVisible(Renderable renderable)
        {
            var ContextHeight = Context?.Bounds?.Height ?? 0;
            int HeightAfter = GetHeightAllChildsAfter(renderable);
            if (HeightAfter > ContextHeight)
            {
                return false;
            }
            return true;
        }


        private void setChildContext(Label UiElement, int ChildContextPosition)
        {
            if (Context == null)
            {
                throw new ArgumentNullException();
            }
            if (UiElement.IsFixed())
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

        public override Context GetContext(Renderable renderable, Context context)
        {
            if (context.GlobalPosition == null)
            {
                throw new ArgumentNullException();
            }
            int ChildContextPosition = GetHeightOf(renderable);
            if (renderable.IsFixed())
            {
                return new Context(context.GlobalPosition, new Bound(0, context.Bounds?.Width ?? 0));
            }
            else
            {
                return new Context(new Position(ChildContextPosition, context.GlobalPosition?.x ?? 0), new Bound(0, context.Bounds?.Width ?? 0));
            }
        }

        private int GetHeightOf(Renderable renderableToFind)
        {
            int ChildContextPosition = 0;
            foreach (UIElement renderable in Childs)
            {
                if (!renderable.IsFixed())
                {
                    if (renderable == renderableToFind)
                    {
                        return ChildContextPosition;
                    }
                    ChildContextPosition += renderable.Height;
                }
            }
            return 0;
        }

        public override bool IsFixed()
        {
            return false;
        }

        public override Position GetGlobalPosition(Context context)
        {
            return context.GlobalPosition;
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return new ScreenDisplay(bound);
        }
    }
}