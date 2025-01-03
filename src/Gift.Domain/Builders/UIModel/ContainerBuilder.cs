using System;
using System.Collections.Generic;
using System.Globalization;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public abstract class ContainerBuilder : UIElementBuilder, IBuilder<Container>
    {
        protected IBorder _border = new NoBorder();
        protected Size _bound = new Size(0, 0);
        protected Color backColor = Color.Default;
        protected Color frontColor = Color.Default;
        protected readonly List<UIElement> _selectableElements = [];
        protected readonly List<UIElement> _unSelectableElements = [];
        protected int? _height;
        protected int? _width;
        protected char _fillingChar = ' ';
        protected bool _isSelectableContainer = false;
        protected string _id = Guid.NewGuid().ToString();

        public virtual ContainerBuilder WithBound(Size bound)
        {
            _bound = bound;
            return this;
        }

        public virtual ContainerBuilder WithBound(string boundStr, IBoundMapper mapper)
        {
            return WithBound(mapper.ToBound(boundStr));
        }

        public virtual ContainerBuilder WithHeight(int height)
        {
            _height = height;
            return this;
        }

        public virtual ContainerBuilder WithHeight(string heightStr)
        {
            return WithHeight(int.Parse(heightStr, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat));
        }

        public virtual ContainerBuilder WithWidth(int width)
        {
            _width = width;
            return this;
        }

        public virtual ContainerBuilder WithWidth(string widthStr)
        {
            return WithWidth(int.Parse(widthStr, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat));
        }

        public virtual ContainerBuilder WithSelectableElement(UIElement element)
        {
            _selectableElements.Add(element);
            return this;
        }

        public virtual ContainerBuilder WithUnSelectableElement(UIElement element)
        {
            _unSelectableElements.Add(element);
            return this;
        }

        public virtual ContainerBuilder IsSelectableContainer(bool isSelectableContainer)
        {
            _isSelectableContainer = isSelectableContainer;
            return this;
        }

        public virtual ContainerBuilder IsSelectableContainer(string isSelectableContainer, IBooleanMapper boolMapper)
        {
            return IsSelectableContainer(boolMapper.ToBool(isSelectableContainer));
        }

        public virtual ContainerBuilder WithFillingChar(char fillingChar)
        {
            _fillingChar = fillingChar;
            return this;
        }

        public virtual ContainerBuilder WithFillingChar(string fillingChar)
        {
            return WithFillingChar(fillingChar.ToCharArray()[0]);
        }

        public override ContainerBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }

        public override ContainerBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            return WithBorder(mapper.ToBorder(borderStr));
        }

        public override ContainerBuilder WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }

        public override ContainerBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            return WithBackgroundColor(mapper.ToColor(colorStr));
        }


        public override ContainerBuilder WithForegroundColor(Color color)
        {
            frontColor = color;
            return this;
        }

        public override ContainerBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            return WithForegroundColor(mapper.ToColor(colorStr));
        }

        public override ContainerBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public abstract override Container Build();
    }
}
