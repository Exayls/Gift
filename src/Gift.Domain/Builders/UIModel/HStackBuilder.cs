using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public class HStackBuilder : ContainerBuilder
    {
        public override HStackBuilder WithBound(Size bound)
        {
            return (HStackBuilder) base.WithBound(bound);
        }

        public override HStackBuilder WithBound(string boundStr, IBoundMapper mapper)
        {
            return (HStackBuilder) base.WithBound(boundStr, mapper);
        }

        public override HStackBuilder WithHeight(int height)
        {
            return (HStackBuilder) base.WithHeight(height);
        }

        public override HStackBuilder WithHeight(string heightStr)
        {
            return (HStackBuilder) base.WithHeight(heightStr);
        }

        public override HStackBuilder WithWidth(int width)
        {
            return (HStackBuilder) base.WithWidth(width);
        }

        public override HStackBuilder WithWidth(string widthStr)
        {
            return (HStackBuilder) base.WithWidth(widthStr);
        }

        public override HStackBuilder WithSelectableElement(UIElement element)
        {
            return (HStackBuilder) base.WithSelectableElement(element);
        }

        public override HStackBuilder WithUnSelectableElement(UIElement element)

        {
            return (HStackBuilder) base.WithUnSelectableElement(element);
        }

        public override HStackBuilder IsSelectableContainer(bool isSelectableContainer)
        {
            return (HStackBuilder) base.IsSelectableContainer(isSelectableContainer);
        }

        public override HStackBuilder IsSelectableContainer(string isSelectableContainer, IBooleanMapper boolMapper)
        {
            return (HStackBuilder) base.IsSelectableContainer(isSelectableContainer, boolMapper);
        }

        public override HStackBuilder WithFillingChar(char fillingChar)
        {
            return (HStackBuilder) base.WithFillingChar(fillingChar);
        }

        public override HStackBuilder WithFillingChar(string fillingChar)
        {
            return (HStackBuilder) base.WithFillingChar(fillingChar);
        }

        public override HStackBuilder WithBorder(IBorder border)
        {
            return (HStackBuilder) base.WithBorder(border);
        }

        public override HStackBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            return (HStackBuilder) base.WithBorder(borderStr, mapper);
        }

        public override HStackBuilder WithBackgroundColor(Color color)
        {
            return (HStackBuilder) base.WithBackgroundColor(color);
        }

        public override HStackBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            return (HStackBuilder) base.WithBackgroundColor(colorStr, mapper);
        }

        public override HStackBuilder WithForegroundColor(Color color)
        {
            return (HStackBuilder) base.WithForegroundColor(color);
        }

        public override HStackBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            return (HStackBuilder) base.WithForegroundColor(colorStr, mapper);
        }

        public override HStackBuilder WithId(string id)
        {
            return (HStackBuilder) base.WithId(id);
        }

        public override HStack Build()
        {
            var bound = new Size(_height ?? _bound.Height, _width ?? _bound.Width);
            var hstack = new HStack(_border,
                                    bound,
                                    frontColor: frontColor,
                                    backColor: backColor,
                                    isSelectableContainer: _isSelectableContainer,
                                    id: _id,
                                    fillingChar: _fillingChar);
            foreach (UIElement element in _unSelectableElements)
            {
                hstack.Add(element);
            }
            foreach (UIElement element in _selectableElements)
            {
                hstack.AddSelectableChild(element);
            }
            return hstack;
        }
    }
}
