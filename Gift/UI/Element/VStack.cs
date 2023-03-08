using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public class VStack : Container
    {
        private readonly IScreenDisplayFactory _screenDisplayFactory;

        public override int Height
        {
            get
            {
                if (Bound.Height != 0)
                {
                    return Bound.Height;
                }
                int HeightAllChilds = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        HeightAllChilds += renderable.Height;
                    }
                }
                return Border.Thickness * 2 + HeightAllChilds;
            }
        }
        public override int Width
        {
            get
            {
                if (Bound.Width != 0)
                {
                    return Bound.Width;
                }
                int maxWidthChild = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        if (maxWidthChild < renderable.Width)
                            maxWidthChild = renderable.Width;
                    }
                }
                return Border.Thickness * 2 + maxWidthChild;
            }
        }

        public VStack(IBorder border, IScreenDisplayFactory screenDisplayFactory) : this(border, screenDisplayFactory, new Bound(0, 0))
        {
        }

        public VStack(IBorder border, IScreenDisplayFactory screenDisplayFactory, Bound bound) : base(bound, border)
        {
            _screenDisplayFactory = screenDisplayFactory;
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
                return new Context(
                    new Position(thickness + ChildContextPosition + context.GlobalPosition.y
                               , thickness + context.GlobalPosition.x),
                    new Bound(renderable.Height, renderable.Width));
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
            return new Position(context.GlobalPosition.y,
                                context.GlobalPosition.x);
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return GetDisplay(bound, GiftBase.FILLINGCHAR);
        }

        public IScreenDisplay GetDisplay(Bound bound, char fillingChar)
        {
            int thickness = Border.Thickness;
            IScreenDisplay screenDisplay = Border.GetDisplay(bound);
            Bound boundEmptyVStack = new Bound(bound.Height - 2 * thickness, bound.Width - 2 * thickness);
            IScreenDisplay emptyVstackScreen = _screenDisplayFactory.Create(boundEmptyVStack, fillingChar);
            screenDisplay.AddDisplay(emptyVstackScreen, new Position(thickness, thickness));
            return screenDisplay;
        }
    }
}