using System;
using System.Collections.Generic;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Element;
using Microsoft.Extensions.Logging;

namespace Gift.XmlUiParser.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private readonly ILogger<IUIElementRegister> _logger;
        private readonly IBorderMapper _borderMapper;
        private readonly IColorMapper _colorMapper;
        private IDictionary<string, Type> _elements;
        private Dictionary<(Type builderType, string attribute), Func<IBuilder<UIElement>, object, IBuilder<UIElement>>> _builderMethods;


        public UIElementRegister(ILogger<IUIElementRegister> logger, IBorderMapper borderMapper, IColorMapper colorMapper)
        {
            _logger = logger;
            _borderMapper = borderMapper;
            _colorMapper = colorMapper;
            _logger = logger;
            _elements = new Dictionary<string, Type>();
            _builderMethods = new Dictionary<(Type builderType, string attribute), Func<IBuilder<UIElement>, object, IBuilder<UIElement>>>();


            this.Register<GiftUIBuilder>("GiftUI");
            this.Register<LabelBuilder>("Label");
            this.Register<VStackBuilder>("VStack");
            this.Register<HStackBuilder>("HStack");

        }

        public Type GetBuilder(string typeName)
        {
            string key = typeName.ToLower();
            if (!_elements.ContainsKey(key))
            {
                throw new NotSupportedException("Unknown component: " + typeName);
            }
            return _elements[key];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod<Builder>(string attribute)
        {
            string key = attribute.ToLower();
            return _builderMethods[(typeof(Builder), key)];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(Type builder, string attribute)
        {
            string key = attribute.ToLower();
            return _builderMethods[(builder, key)];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(string builderName, string attribute)
        {
            string key = attribute.ToLower();
            return _builderMethods[(_elements[builderName], key)];
        }

        public void Register(string name, Type type)
        {
            _elements.Add(name.ToLower(), type);
        }

        public void Register<TBuilder>(string name)
            where TBuilder : IUIElementBuilder
        {
            var buildertype = typeof(TBuilder);
            _elements.Add(name.ToLower(), buildertype);

            if (typeof(IContainerBuilder).IsAssignableFrom(buildertype))
            {
                this.Register<IContainerBuilder>(buildertype, "bound", (b, bd) => b.WithBound(bd));
            }
            if (typeof(IUIElementBuilder).IsAssignableFrom(buildertype))
            {
                this.Register<IUIElementBuilder>(buildertype, "backgroundcolor", (b, c) => b.WithBackgroundColor(c, _colorMapper));
                this.Register<IUIElementBuilder>(buildertype, "backcolor", (b, c) => b.WithBackgroundColor(c, _colorMapper));

                this.Register<IUIElementBuilder>(buildertype, "frontgroundcolor", (b, c) => b.WithForegroundColor(c, _colorMapper));
                this.Register<IUIElementBuilder>(buildertype, "frontcolor", (b, c) => b.WithForegroundColor(c, _colorMapper));

                this.Register<IUIElementBuilder>(buildertype, "border", (b, a) => b.WithBorder(a, _borderMapper));
            }
        }


        public void Register<T>(Type builderType, string attributeName, Func<T, string, T> builderMethod)
            where T : IUIElementBuilder
        {
            Register<T, string>(builderType, attributeName, builderMethod);
        }

        public void Register<T1, T2>(Type builderType, string attributeName, Func<T1, T2, T1> builderMethod)
            where T1 : IUIElementBuilder
        {
            // _builderMethods.Add((typeof(T1), elementName), builderMethod);
            _builderMethods.Add(
                    (builderType, attributeName),
                    (builder, arg) => builderMethod((T1)builder, (T2)arg)
                );
        }
    }
}
