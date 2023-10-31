using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class VStackBuilder : IContainerBuilder<VStack>
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public IUIElementBuilder<VStack> WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public IContainerBuilder<VStack> WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        public IUIElementBuilder<VStack> WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }

        public IUIElementBuilder<VStack> WithForegroundColor(Color color)
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
