using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public class VStack : Container
    {

        public override int Height
        {
            get
            {
                if (Size.Height != 0)
                {
                    return Size.Height;
                }
                int HeightAllChilds = 0;
                foreach (UIElement renderable in Childs)
                {
                    if (!renderable.HasNoSize())
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
                if (Size.Width != 0)
                {
                    return Size.Width;
                }
                int maxWidthChild = 0;
                foreach (UIElement renderable in Childs)
                {
                    if (!renderable.HasNoSize())
                    {
                        if (maxWidthChild < renderable.Width)
                            maxWidthChild = renderable.Width;
                    }
                }
                return Border.Thickness * 2 + maxWidthChild;
            }
        }


        public VStack(IBorder border, Size bound, bool isSelectableContainer, Color frontColor, Color backColor, string id)
            : base(bound, border, frontColor: frontColor, backColor: backColor, isSelectableContainer: isSelectableContainer, id:id)
        {
        }

        public override Position GetContext(Renderable renderable, Position position)
        {
            int ChildContextPosition = GetHeightRenderable(renderable);
            return new Position(ChildContextPosition - ScrollIndex, 0);
        }

        private int GetHeightRenderable(Renderable renderableToFind)
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
                    ChildContextPosition += renderable.Height;
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
            return position;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            int thickness = Border.Thickness;

            var fullSize = sizeCalculator.GetTrueSize(this);
            Color frontColor = colorResolver.GetFrontColor(this, configuration);
            Color backColor = colorResolver.GetBackColor(this, configuration);
            Size sizeInVStack = new Size(fullSize.Height - 2 * thickness, fullSize.Width - 2 * thickness);

            IScreenDisplay emptyVstackScreen = 
				new ScreenDisplayBuilder()
				.WithBound(sizeInVStack)
				.WithBackColor(backColor)
				.WithFrontColor(frontColor)
				.WithChar(configuration.FillingChar)
				.Build();
            return emptyVstackScreen;
        }

        public override bool IsSimilarTo(UIElement uiElement)
        {
            if (!(uiElement is VStack))
                return false;
            var element = (VStack)uiElement;
            return base.IsSimilarTo(uiElement);
        }
    }
}
