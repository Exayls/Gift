using System.Collections.Generic;
using System.Globalization;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public class VStackBuilder : IContainerBuilder
    {
        private IBorder _border = new NoBorder();
        private Size _bound = new Size(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private IList<UIElement> selectableElements = new List<UIElement>();
        private IList<UIElement> unSelectableElements = new List<UIElement>();
        private int? _height;
        private int? _width;

        private bool _isSelectableContainer = false;

        public VStackBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }
        public VStackBuilder WithBound(Size bound)
        {
            _bound = bound;
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

        public VStackBuilder WithSelectableElement(UIElement element)
        {
            selectableElements.Add(element);
            return this;
        }

        public VStackBuilder WithUnSelectableElement(UIElement element)
        {
            unSelectableElements.Add(element);
            return this;
        }

        public VStackBuilder IsSelectableContainer(bool isSelectableContainer)
        {
            _isSelectableContainer = isSelectableContainer;
            return this;
        }

        public VStackBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public VStackBuilder WithWidth(int width)
        {
            _width = width;
            return this;
        }

        public VStack Build()
        {
            var bound = new Size(_height ?? _bound.Height, _width ?? _bound.Width);
            var vstack = new VStack(_border, screenDisplayFactory, bound, frontColor: frontColor, backColor: backColor,
                                    isSelectableContainer: _isSelectableContainer);
            foreach (UIElement element in unSelectableElements)
            {
                vstack.Add(element);
            }
            foreach (UIElement element in selectableElements)
            {
                vstack.AddSelectableChild(element);
            }
            return vstack;
        }

        UIElement IBuilder<UIElement>.Build()
        {
            return Build();
        }

        Container IBuilder<Container>.Build()
        {
            return Build();
        }

        IContainerBuilder IContainerBuilder.WithBound(Size bound)
        {
            return WithBound(bound);
        }

        IContainerBuilder IContainerBuilder.WithSelectableElement(UIElement element)
        {
            return WithSelectableElement(element);
        }

        IContainerBuilder IContainerBuilder.WithUnSelectableElement(UIElement element)
        {
            return WithUnSelectableElement(element);
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

        IContainerBuilder IContainerBuilder.IsSelectableContainer(bool isSelectableContainer)
        {
            return IsSelectableContainer(isSelectableContainer);
        }

        public IUIElementBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            return WithBorder(mapper.ToBorder(borderStr));
        }

        public IUIElementBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            return WithBackgroundColor(mapper.ToColor(colorStr));
        }

        public IUIElementBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            return WithForegroundColor(mapper.ToColor(colorStr));
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

        public IContainerBuilder IsSelectableContainer(string isSelectableContainer, IBooleanMapper boolMapper)
        {
            return IsSelectableContainer(boolMapper.ToBool(isSelectableContainer));
        }
    }
}
