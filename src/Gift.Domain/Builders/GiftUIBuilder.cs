using System;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class GiftUIBuilder : IContainerBuilder<GiftUI>
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

        public IContainerBuilder<GiftUI> WithBound(Bound bound)
        {
            _bound = bound;
            return this;
        }

        public GiftUI Build()
        {
            return new GiftUI(bound: _bound,
                              border: _border,
                              frontColor: _frontColor,
                              backColor: _backColor);
        }

        public IUIElementBuilder<GiftUI> WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }

        public IUIElementBuilder<GiftUI> WithBackgroundColor(Color color)
        {
			_backColor = color;
            return this;
        }

        public IUIElementBuilder<GiftUI> WithForegroundColor(Color color)
        {
			_frontColor = color;
            return this;
        }
    }
}
