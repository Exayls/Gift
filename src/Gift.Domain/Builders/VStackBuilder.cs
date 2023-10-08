using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.src.Builders
{
    public class VStackBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public VStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public VStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        public VStackBuilder WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }

        public VStackBuilder WithForegroundColor(Color color)
        {
            frontColor = color;
            return this;
        }

        public VStack Build()
        {
            return new VStack(Border,
                              screenDisplayFactory,
                              Bound,
                              frontColor: frontColor,
                              backColor: backColor);
        }

    }
}
