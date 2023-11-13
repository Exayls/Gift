using System;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class GiftUIBuilder : IContainerBuilder
    {
        private Bound _bound;
        private IBorder _border;
        private Color _frontColor = Color.Default;
        private Color _backColor = Color.Default;

        public GiftUIBuilder()
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                _bound = new Bound(Console.WindowHeight, Console.WindowWidth);
            }
            else
            {
                _bound = new Bound(0, 0);
            }
            _border = new NoBorder();
        }

        public GiftUIBuilder WithBound(Bound bound)
        {
            _bound = bound;
            return this;
        }

        public GiftUIBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }

        public GiftUIBuilder WithBackgroundColor(Color color)
        {
            _backColor = color;
            return this;
        }

        public GiftUIBuilder WithForegroundColor(Color color)
        {
            _frontColor = color;
            return this;
        }

        public GiftUI Build()
        {
            return new GiftUI(bound: _bound,
                              border: _border,
                              frontColor: _frontColor,
                              backColor: _backColor);
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

        IContainerBuilder IContainerBuilder.WithBound(string boundStr)
        {
			boundStr.Split(new[]{',', ';'})
			var bound = 
			return WithBound(bound);
        }
    }
}
