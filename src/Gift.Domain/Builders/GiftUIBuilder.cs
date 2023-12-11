using System;
using System.Collections.Generic;
using System.Globalization;
using Gift.Domain.Builders.Mappers;
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
        private IList<UIElement> selectableElements = new List<UIElement>();
        private IList<Container> selectableContainers = new List<Container>();
        private int? _height = null;
        private int? _width = null;

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

        public GiftUIBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public GiftUIBuilder WithWidth(int width)
        {
            _width = width;
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

        public GiftUIBuilder WithSelectableElement(UIElement element)
        {
            this.selectableElements.Add(element);
            return this;
        }

        public GiftUIBuilder WithSelectableContainer(Container element)
        {
            this.selectableContainers.Add(element);
            return this;
        }

        public GiftUI Build()
        {
			var bound = new Bound(_height??_bound.Height, _width??_bound.Width);
            var giftui = new GiftUI(bound: bound,
                              border: _border,
                              frontColor: _frontColor,
                              backColor: _backColor);
            foreach (UIElement element in selectableElements)
            {
                giftui.AddSelectableChild(element);

            }
            foreach (Container element in selectableContainers)
            {
                giftui.SelectableContainers.Add(element);

            }
            return giftui;
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

        IContainerBuilder IContainerBuilder.WithSelectableElement(UIElement element)
        {
            return WithSelectableElement(element);
        }

        IContainerBuilder IContainerBuilder.WithHeight(int height)
        {
            return WithHeight(height);
        }

        IContainerBuilder IContainerBuilder.WithWidth(int width)
        {
            return WithWidth(width);
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

        public IContainerBuilder WithBound(string boundStr, IBoundMapper mapper)
        {
            return WithBound(mapper.ToBound(boundStr));
        }

        public IUIElementBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            throw new NotImplementedException();
        }

        public IUIElementBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            throw new NotImplementedException();
        }

        public IUIElementBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            throw new NotImplementedException();
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
