using System.Collections.Generic;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class VStackBuilder : IContainerBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private IList<UIElement> selectableElements = new List<UIElement>();

        public VStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public VStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
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

        public VStack Build()
        {
            var vstack =  new VStack(Border,
                              screenDisplayFactory,
                              Bound,
                              frontColor: frontColor,
                              backColor: backColor);
			foreach(UIElement element in selectableElements)
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

        IContainerBuilder IContainerBuilder.WithBound(Bound bound)
        {
            return WithBound(bound);
        }

        IContainerBuilder IContainerBuilder.WithSelectableElement(UIElement element)
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

    }
}
