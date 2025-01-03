using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public class VStackBuilder : ContainerBuilder
    {
        public override VStackBuilder WithBound(Size bound)
        {
            return (VStackBuilder) base.WithBound(bound);
        }

        public override VStackBuilder WithBound(string boundStr, IBoundMapper mapper)
        {
            return (VStackBuilder) base.WithBound(boundStr, mapper);
        }

        public override VStackBuilder WithHeight(int height)
        {
            return (VStackBuilder) base.WithHeight(height);
        }

        public override VStackBuilder WithHeight(string heightStr)
        {
            return (VStackBuilder) base.WithHeight(heightStr);
        }

        public override VStackBuilder WithWidth(int width)
        {
            return (VStackBuilder) base.WithWidth(width);
        }

        public override VStackBuilder WithWidth(string widthStr)
        {
            return (VStackBuilder) base.WithWidth(widthStr);
        }

        public override VStackBuilder WithSelectableElement(UIElement element)
        {
            return (VStackBuilder) base.WithSelectableElement(element);
        }

        public override VStackBuilder WithUnSelectableElement(UIElement element)

        {
            return (VStackBuilder) base.WithUnSelectableElement(element);
        }

        public override VStackBuilder IsSelectableContainer(bool isSelectableContainer)
        {
            return (VStackBuilder) base.IsSelectableContainer(isSelectableContainer);
        }

        public override VStackBuilder IsSelectableContainer(string isSelectableContainer, IBooleanMapper boolMapper)
        {
            return (VStackBuilder) base.IsSelectableContainer(isSelectableContainer, boolMapper);
        }

        public override VStackBuilder WithFillingChar(char fillingChar)
        {
            return (VStackBuilder) base.WithFillingChar(fillingChar);
        }

        public override VStackBuilder WithFillingChar(string fillingChar)
        {
            return (VStackBuilder) base.WithFillingChar(fillingChar);
        }

        public override VStackBuilder WithBorder(IBorder border)
        {
            return (VStackBuilder) base.WithBorder(border);
        }

        public override VStackBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            return (VStackBuilder) base.WithBorder(borderStr, mapper);
        }

        public override VStackBuilder WithBackgroundColor(Color color)
        {
            return (VStackBuilder) base.WithBackgroundColor(color);
        }

        public override VStackBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            return (VStackBuilder) base.WithBackgroundColor(colorStr, mapper);
        }

        public override VStackBuilder WithForegroundColor(Color color)
        {
            return (VStackBuilder) base.WithForegroundColor(color);
        }

        public override VStackBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            return (VStackBuilder) base.WithForegroundColor(colorStr, mapper);
        }

        public override VStackBuilder WithId(string id)
        {
            return (VStackBuilder) base.WithId(id);
        }

        public override VStack Build()
        {
            var bound = new Size(_height ?? _bound.Height, _width ?? _bound.Width);
            var vstack = new VStack(_border,
                                    bound,
                                    frontColor: frontColor,
                                    backColor: backColor,
                                    isSelectableContainer: _isSelectableContainer,
                                    id: _id,
                                    fillingChar: _fillingChar);
            foreach (UIElement element in _unSelectableElements)
            {
                vstack.Add(element);
            }
            foreach (UIElement element in _selectableElements)
            {
                vstack.AddSelectableChild(element);
            }
            return vstack;
        }
    }
}
