using System;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.UIModel.Element
{
    public abstract class UIElement : Renderable
    {

        public abstract int Height { get; }
        public abstract int Width { get; }
        public IBorder Border { get; set; }
        public Color FrontColor { get; private set; }
        public Color BackColor { get; private set; }

        private bool isSelectedElement;
        public bool IsSelectedElement
        {
            get => isSelectedElement;
            set
            {
                isSelectedElement = value;
            }
        }

        public bool IsInSelectedContainer { get; set; }

        protected UIElement(IBorder? border = null, Color frontColor = Color.Default, Color backColor = Color.Default)
        {
            Border = border ?? new NoBorder();
            FrontColor = frontColor;
            BackColor = backColor;
        }

        public abstract IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator);
        public abstract IScreenDisplay GetDisplayBorder(IConfiguration configuratione, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator);
        public abstract Position GetRelativePosition(Position position);
        public abstract bool IsFixed();

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
            if (!this.Border.IsSimilarTo(element.Border))
                return false;
            if (!this.BackColor.Equals(element.BackColor))
                return false;
            if (!this.FrontColor.Equals(element.FrontColor))
                return false;
            return true;
        }

    }
}
