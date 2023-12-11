using System.Globalization;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class HStackBuilder : IContainerBuilder
    {
        private IBorder _border = new NoBorder();
        private Bound _bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private int? _height;
        private int? _width;

        public HStackBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }
        public HStackBuilder WithBound(Bound bound)
        {
            _bound = bound;
            return this;
        }

        public HStackBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public HStackBuilder WithWidth(int width)
        {
            _width = width;
            return this;
        }


        public HStackBuilder WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }

        public HStackBuilder WithForegroundColor(Color color)
        {
            frontColor = color;
            return this;
        }

        public HStack Build()
        {
			var bound = new Bound(_height??_bound.Height, _width??_bound.Width);
            return new HStack(_border,
                              screenDisplayFactory,
                              bound,
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

        public IContainerBuilder WithSelectableElement(UIElement element)
        {
			return WithSelectableElement(element);
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

        IContainerBuilder IContainerBuilder.WithHeight(int height)
        {
            return WithHeight(height);
        }

        IContainerBuilder IContainerBuilder.WithWidth(int width)
        {
            return WithWidth(width);
        }

        public IContainerBuilder WithBound(string boundStr)
        {
            throw new System.NotImplementedException();
        }

        public IUIElementBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            throw new System.NotImplementedException();
        }

        public IUIElementBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            throw new System.NotImplementedException();
        }

        public IUIElementBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            throw new System.NotImplementedException();
        }
        public IContainerBuilder WithBound(string boundStr, IBoundMapper mapper)
        {
            return WithBound(mapper.ToBound(boundStr));
        }

        public IContainerBuilder WithHeight(string heightStr)
        {
            return WithHeight(int.Parse(heightStr, NumberStyles.Integer));
        }

        public IContainerBuilder WithWidth(string widthStr)
        {
            return WithWidth(int.Parse(widthStr, NumberStyles.Integer));
        }
    }
}
