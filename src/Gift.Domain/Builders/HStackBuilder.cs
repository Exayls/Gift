﻿using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public class HStackBuilder : IContainerBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public HStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public HStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
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
            return new HStack(Border,
                              screenDisplayFactory,
                              Bound,
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
