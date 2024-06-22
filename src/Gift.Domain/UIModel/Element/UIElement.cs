using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.UIModel.Services;

namespace Gift.Domain.UIModel.Element
{
    public abstract class UIElement : IRenderable
    {

        public abstract int Height { get; }
        public abstract int Width { get; }
        public IBorder Border { get; set; }
        public Color FrontColor { get; private set; }
        public Color BackColor { get; private set; }
        public string Id { get; }
        public bool IsSelectedElement { get; set; }

        public bool IsInSelectedContainer { get; set; }

        protected UIElement(IBorder? border, Color frontColor, Color backColor, string id)
        {
            Border = border ?? new NoBorder();
            FrontColor = frontColor;
            BackColor = backColor;
            Id = id;
        }

        public abstract IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator);
        public abstract IScreenDisplay GetDisplayBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator);
        public abstract Position GetRelativePosition(Position position);
        public abstract bool HasNoSize();

        public IScreenDisplay GetDisplayWithBorder(char fillingChar, ColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            int thickness = Border.Thickness;
            IScreenDisplay screenDisplay = GetDisplayBorder(new DefaultConfiguration(), colorResolver, sizeCalculator);
            IScreenDisplay emptyHstackScreen = GetDisplayWithoutBorder(new Configuration(fillingChar: fillingChar), colorResolver, sizeCalculator);
            screenDisplay.AddDisplay(emptyHstackScreen, new Position(thickness, thickness));
            return screenDisplay;
        }


        public virtual bool IsSimilarTo(UIElement element)
        {
            if (!Border.IsSimilarTo(element.Border))
                return false;
            if (!BackColor.Equals(element.BackColor))
                return false;
            if (!FrontColor.Equals(element.FrontColor))
                return false;
            return true;
        }

    }
}
