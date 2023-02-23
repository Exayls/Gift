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

        public VStack() : this(new NoBorder())
        {
        }
        public VStack(IBorder border)
        {
            Border = border;
        }

        public void AddChild(IUIElement uIElement)
        {
            Childs.Add(uIElement);
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

        public override Context GetContextRenderable(Renderable renderable, Context context)
        {
            int ChildContextPosition = GetHeightRenderableFromTop(renderable);
            if (renderable.IsFixed())
            {
                return new Context(
                    context.GlobalPosition,
                    new Bound(0, 0));
            }
            else
            {
                int thickness = Border.Thickness;
                if (thickness >0)
                {
                    return new Context(
                        new Position(thickness+ChildContextPosition,thickness),
                        new Bound(0, 0));
                }
                return new Context(
                    new Position(ChildContextPosition, context.GlobalPosition?.x ?? 0),
                    new Bound(0, 0));
            }
        }

        private int GetHeightRenderableFromTop(Renderable renderableToFind)
        {
            int ChildContextPosition = 0;
            foreach (IUIElement renderable in Childs)
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
            return GetDisplay(bound, GiftBase.FILLINGCHAR);
        }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar)
        {
            int thickness = Border.Thickness;
            ScreenDisplay screenDisplay = new ScreenDisplay(bound, Border.BorderChar);
            screenDisplay.AddDisplay(new ScreenDisplay(
                new Bound(bound.Height - (2 * thickness), bound.Width - (2 * thickness)), fillingChar),
                new Position(thickness, thickness));
            return screenDisplay;
        }
    }
}