using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class VStackBuilder : IContainerBuilder
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

        UIElement IBuilder<UIElement>.Build()
        {
			return Build();
        }

        Container IBuilder<Container>.Build()
        {
			return Build();
        }

        IContainerBuilder IContainerBuilder.WithBound(Bound bound)
        {
			return WithBound(bound);
        }

        IUIElementBuilder IUIElementBuilder.WithBorder(IBorder border)
        {
			return WithBorder(border);
        }

        IUIElementBuilder IUIElementBuilder.WithBackgroundColor(Color color)
        {
			return WithBackgroundColor(color);
        }

        IUIElementBuilder IUIElementBuilder.WithForegroundColor(Color color)
        {
			return WithForegroundColor(color);
        }
    }
}
