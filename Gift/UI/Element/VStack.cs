using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public class VStack : Container
    {

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

        public VStack(IBorder border, IScreenDisplayFactory screenDisplayFactory, Bound bound) : base(screenDisplayFactory,bound, border)
        {
        }

        public void AddChild(IUIElement uIElement)
        {
            Childs.Add(uIElement);
        }


        public override Context GetContextRenderable(IRenderable renderable, Context context)
        {
            int ChildContextPosition = GetHeightRenderableFromTop(renderable);
            if (renderable.IsFixed())
            {
                return new Context(
                    context.Position,
                    new Bound(0, 0));
            }
            else
            {
                int thickness = Border.Thickness;
                return new Context(
                    new Position(thickness + ChildContextPosition + context.Position.y
                               , thickness + context.Position.x),
                    new Bound(renderable.Height, renderable.Width));
            }
        }
        public override Context GetContextRelativeRenderable(IRenderable renderable, Context context)
        {
            int ChildContextPosition = GetHeightRenderableFromTop(renderable);
            if (renderable.IsFixed())
            {
                return new Context(
                    new Position(ChildContextPosition
                               , 0),
                    new Bound(0, 0));
            }
            else
            {
                return new Context(
                    new Position(ChildContextPosition
                               , 0),
                    new Bound(renderable.Height, renderable.Width));
            }
        }

        private int GetHeightRenderableFromTop(IRenderable renderableToFind)
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

        public override Position GetRelativePosition(Context context)
        {
            return new Position(context.Position.y,
                                context.Position.x);
        }
        public override Position GetGlobalPosition(Context context)
        {
            return new Position(context.Position.y,
                                context.Position.x);
        }

        public override IScreenDisplay GetDisplay(Bound bound)
        {
            return GetDisplayWithBorder(bound, GiftBase.FILLINGCHAR);
        }

        public IScreenDisplay GetDisplayWithBorder(Bound bound, char fillingChar)
        {
            int thickness = Border.Thickness;
            IScreenDisplay screenDisplay = GetDisplayBorder(bound);
            IScreenDisplay emptyVstackScreen = GetDisplayWithoutBorder(bound);
            screenDisplay.AddDisplay(emptyVstackScreen, new Position(thickness, thickness));
            return screenDisplay;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound)
        {
            int thickness = Border.Thickness;
            Bound boundEmptyVStack = new Bound(bound.Height - 2 * thickness, bound.Width - 2 * thickness);
            IScreenDisplay emptyVstackScreen = _screenDisplayFactory.Create(boundEmptyVStack, GiftBase.FILLINGCHAR);
            return emptyVstackScreen;
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound)
        {
            IScreenDisplay screenDisplay = Border.GetDisplay(bound);
            return screenDisplay;
        }
    }
}