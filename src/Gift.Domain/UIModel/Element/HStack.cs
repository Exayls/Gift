using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public class HStack : Container
    {

        public override int Height
        {
            get
            {
                if (Size.Height != 0)
                {
                    return Size.Height;
                }
                int maxHeightChild = 0;
                foreach (UIElement renderable in Childs)
                {
                    if (!renderable.HasNoSize())
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
                if (Size.Width != 0)
                {
                    return Size.Width;
                }
                int WidthAllChilds = 0;
                foreach (UIElement renderable in Childs)
                {
                    if (!renderable.HasNoSize())
                    {
                        WidthAllChilds += renderable.Width + 1;
                    }
                }
                WidthAllChilds -= 1;
                return Border.Thickness * 2 + WidthAllChilds;
            }
        }

        public HStack(IBorder border,
                      IScreenDisplayFactory screenDisplayFactory,
                      Size bound,
                      Color frontColor,
                      Color backColor,
                      bool IsSelectableContainer,
					  string id)
            : base(screenDisplayFactory, bound, border, frontColor: frontColor, backColor: backColor, isSelectableContainer: IsSelectableContainer, id)
        {
        }

        public override Position GetContext(Renderable renderable, Position position)
        {
            int ChildContextPosition = GetWidthRenderable(renderable);
            return new Position(0, ChildContextPosition - ScrollIndex);
        }

        private int GetWidthRenderable(Renderable renderableToFind)
        {
            int ChildContextPosition = 0;
            foreach (UIElement renderable in Childs)
            {
                if (!renderable.HasNoSize())
                {
                    if (renderable == renderableToFind)
                    {
                        return ChildContextPosition;
                    }
                    ChildContextPosition += renderable.Width + 1;
                }
            }
            return 0;
        }

        public override bool HasNoSize()
        {
            return false;
        }

        public override Position GetRelativePosition(Position position)
        {
            return new Position(position.y,
                                position.x);
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            int thickness = Border.Thickness;
            var fullSize = sizeCalculator.GetTrueSize(this);
            Size boundEmptyVStack = new Size(fullSize.Height - 2 * thickness, fullSize.Width - 2 * thickness);
            IScreenDisplay emptyVstackScreen = _screenDisplayFactory.Create(
                boundEmptyVStack, FrontColor == Color.Default ? configuration.DefaultFrontColor : FrontColor,
                BackColor == Color.Default ? configuration.DefaultBackColor : BackColor, configuration.FillingChar);
            return emptyVstackScreen;
        }

        public override bool IsSimilarTo(UIElement uiElement)
        {
            if (!(uiElement is HStack))
                return false;
            var element = (HStack)uiElement;
            return base.IsSimilarTo(uiElement);
        }
    }
}
