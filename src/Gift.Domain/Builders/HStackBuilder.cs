using System.Collections.Generic;
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
        private IList<UIElement> unSelectableElements = new List<UIElement>();
        private IList<UIElement> selectableElements = new List<UIElement>();

        private bool _isSelectableContainer = false;

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

        public HStackBuilder WithSelectableElement(UIElement element)
        {
            selectableElements.Add(element);
            return this;
        }
        public HStackBuilder WithUnSelectableElement(UIElement element)
        {
            unSelectableElements.Add(element);
            return this;
        }

        public HStackBuilder IsSelectableContainer(bool isSelectableContainer)
        {
            _isSelectableContainer = isSelectableContainer;
            return this;
        }

        public HStack Build()
        {
            var bound = new Bound(_height ?? _bound.Height, _width ?? _bound.Width);
            var hstack = new HStack(_border,
                              screenDisplayFactory,
                              bound,
							  IsSelectableContainer:_isSelectableContainer,
                              frontColor: frontColor,
                              backColor: backColor);

            foreach (UIElement element in unSelectableElements)
            {
                hstack.AddUnselectableChild(element);
            }
            foreach (UIElement element in selectableElements)
            {
                hstack.AddSelectableChild(element);
            }
            return hstack;
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
