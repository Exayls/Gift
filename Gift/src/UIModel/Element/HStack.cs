using Gift.UI.Border;
using Gift.UI.Configuration;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.UI.Element
{
    public class HStack : Container
    {

        public override int Height
        {
            get
            {
                if (Bound.Height != 0)
                {
                    return Bound.Height;
                }
                int maxHeightChild = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        if (maxHeightChild < renderable.Height)
                            maxHeightChild = renderable.Height;
                    }
                }
                return Border.Thickness * 2 + maxHeightChild;
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
                int WidthAllChilds = 0;
                foreach (IUIElement renderable in Childs)
                {
                    if (!renderable.IsFixed())
                    {
                        WidthAllChilds += renderable.Width;
                    }
                }
                return Border.Thickness * 2 + WidthAllChilds;
            }
        }

        public HStack(IBorder border,
                      IScreenDisplayFactory screenDisplayFactory,
                      Color frontColor = Color.Default,
                      Color backColor = Color.Default) : this(border, screenDisplayFactory, new Bound(0, 0), frontColor: frontColor, backColor: backColor)
        {
        }

        public HStack(IBorder border,
                      IScreenDisplayFactory screenDisplayFactory,
                      Bound bound,
                      Color frontColor = Color.Default,
                      Color backColor = Color.Default) : base(screenDisplayFactory, bound, border, frontColor: frontColor, backColor: backColor)
        {
        }


        public override Context GetContextRelativeRenderable(IRenderable renderable, Context context)
        {
            int ChildContextPosition = GetWidthRenderable(renderable);
            return new Context(
                new Position(0
                           , ChildContextPosition-ScrollIndex),
                new Bound(renderable.Height, renderable.Width));
        }

        private int GetWidthRenderable(IRenderable renderableToFind)
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
                    ChildContextPosition += renderable.Width;
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

        public IScreenDisplay GetDisplayWithBorder(Bound bound, char fillingChar)
        {
            int thickness = Border.Thickness;
            IScreenDisplay screenDisplay = GetDisplayBorder(bound, new DefaultConfiguration());
            IScreenDisplay emptyVstackScreen = GetDisplayWithoutBorder(bound, new DefaultConfiguration());
            screenDisplay.AddDisplay(emptyVstackScreen, new Position(thickness, thickness));
            return screenDisplay;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bound, IConfiguration configuration)
        {
            int thickness = Border.Thickness;
            Bound boundEmptyVStack = new Bound(bound.Height - 2 * thickness, bound.Width - 2 * thickness);
            IScreenDisplay emptyVstackScreen = _screenDisplayFactory.Create(boundEmptyVStack, FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor, BackColor == Color.Default ? configuration.DefaultBackColor : BackColor, GiftBase.FILLINGCHAR);
            return emptyVstackScreen;
        }

    }
}