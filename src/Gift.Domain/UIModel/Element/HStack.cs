﻿using Gift.Domain.Builders.UIModel.Display;
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
                return (Border.Thickness * 2) + maxHeightChild;
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
                return (Border.Thickness * 2) + WidthAllChilds;
            }
        }

        public HStack(IBorder border,
                      Size bound,
                      bool isSelectableContainer,
                      Color frontColor,
                      Color backColor,
                      string id,
                      char fillingChar)
            : base(bound, border, frontColor: frontColor, backColor: backColor, isSelectableContainer: isSelectableContainer, id, fillingChar: fillingChar)
        {
        }

        public override Position GetContext(IRenderable renderable, Position position)
        {
            int ChildContextPosition = GetWidthRenderable(renderable);
            return new Position(0, ChildContextPosition - _scrollIndex);
        }

        private int GetWidthRenderable(IRenderable renderableToFind)
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
            return new Position(position.Y,
                                position.X);
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            int thickness = Border.Thickness;
            var fullSize = sizeCalculator.GetTrueSize(this);
            Color frontColor = colorResolver.GetFrontColor(this, configuration);
            Color backColor = colorResolver.GetBackColor(this, configuration);
            Size sizeInVStack = new Size(fullSize.Height - (2 * thickness), fullSize.Width - (2 * thickness));

            IScreenDisplay emptyVstackScreen =
                new ScreenDisplayBuilder()
                .WithBound(sizeInVStack)
                .WithBackColor(backColor)
                .WithFrontColor(frontColor)
                .WithChar(_fillingChar)
                .Build();
            return emptyVstackScreen;
        }

        public override bool IsSimilarTo(UIElement element)
        {
            if (element is not HStack)
                return false;
            return base.IsSimilarTo(element);
        }
    }
}
