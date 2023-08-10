using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.Builders
{
    public class HStackBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public HStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public HStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        public HStackBuilder WithBackgroundColor(Color color)
        {
            this.backColor = color;
            return this;
        }

        public HStackBuilder WithForegroundColor(Color color)
        {
            this.frontColor = color;
            return this;
        }

        public HStack Build()
        {
            return new HStack(Border,
                              screenDisplayFactory,
                              Bound,
                              frontColor: frontColor,
                              backColor: backColor);
        }
    }
}
