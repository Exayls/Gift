using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class HStackBuilder : IContainerBuilder<HStack>
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public IUIElementBuilder<HStack> WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public IContainerBuilder<HStack> WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        public IUIElementBuilder<HStack> WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }

        public IUIElementBuilder<HStack> WithForegroundColor(Color color)
        {
            frontColor = color;
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
