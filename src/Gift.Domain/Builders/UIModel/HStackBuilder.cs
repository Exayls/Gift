using System;
using System.Collections.Generic;
using System.Globalization;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public class HStackBuilder : IContainerBuilder
    {
        private IBorder _border = new NoBorder();
        private Size _bound = new Size(0, 0);
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private int? _height;
        private int? _width;
        private IList<UIElement> unSelectableElements = new List<UIElement>();
        private IList<UIElement> selectableElements = new List<UIElement>();

        private bool _isSelectableContainer = false;

        private string _id = Guid.NewGuid().ToString();

        public HStackBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }
        public HStackBuilder WithBound(Size bound)
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

        public HStackBuilder WithId(string id)
        {
            _id = id;
            return this;
        }


        public HStack Build()
        {
            var bound = new Size(_height ?? _bound.Height, _width ?? _bound.Width);
            var hstack = new HStack(_border,
                              bound,
                              IsSelectableContainer: _isSelectableContainer,
                              frontColor: frontColor,
                              backColor: backColor,
							  id: _id);

            foreach (UIElement element in unSelectableElements)
            {
                hstack.Add(element);
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

        IUIElementBuilder IUIElementBuilder.WithId(string id)
        {
            return WithId(id);
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
