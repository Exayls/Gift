using System;
using System.Collections.Generic;
using System.Globalization;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Element;
using Microsoft.Extensions.Logging;

namespace Gift.XmlUiParser.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private readonly ILogger<IUIElementRegister> _logger;
        private readonly IBorderMapper _borderMapper;
        private readonly IBoundMapper _boundMapper;
        private readonly IColorMapper _colorMapper;
        private readonly IBooleanMapper _booleanMapper;
        private readonly Dictionary<string, Type> _elements;
        private readonly Dictionary<(Type builderType, string attribute), Func<IBuilder<UIElement>, object, IBuilder<UIElement>>>
            _builderMethods;

        public UIElementRegister(ILogger<IUIElementRegister> logger, IBorderMapper borderMapper,
                                 IColorMapper colorMapper, IBoundMapper boundMapper, IBooleanMapper booleanMapper)
        {
            _logger = logger;
            _borderMapper = borderMapper;
            _colorMapper = colorMapper;
            _boundMapper = boundMapper;
            _booleanMapper = booleanMapper;
            _logger = logger;
            _elements = [];
            _builderMethods = [];

            Register<LabelBuilder>("Label");
            Register<VStackBuilder>("VStack");
            Register<HStackBuilder>("HStack");

            Register<LabelBuilder>(typeof(LabelBuilder), "text", (b, text) => b.WithText(text));
        }

        public Type GetBuilder(string typeName)
        {
            string key = typeName.ToLower(CultureInfo.CurrentCulture);
            if (!_elements.TryGetValue(key, out Type? value))
            {
                throw new NotSupportedException("Unknown component: " + typeName);
            }
            return value;
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod<TBuilder>(string attribute)
        {
            string key = attribute.ToLower(CultureInfo.CurrentCulture);
            return _builderMethods[(typeof(TBuilder), key)];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(Type builder, string attribute)
        {
            string key = attribute.ToLower(CultureInfo.CurrentCulture);
            return _builderMethods[(builder, key)];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(string builderName, string attribute)
        {
            string key = attribute.ToLower(CultureInfo.CurrentCulture);
            return _builderMethods[(_elements[builderName], key)];
        }

        public void Register(string name, Type type)
        {
            _logger.LogDebug("registering {Element}", name);
            _elements.Add(name.ToLower(CultureInfo.CurrentCulture), type);
        }

        public void Register<TBuilder>(string name)
            where TBuilder : IUIElementBuilder
        {
            var buildertype = typeof(TBuilder);
            _elements.Add(name.ToLower(CultureInfo.CurrentCulture), buildertype);

            if (typeof(IContainerBuilder).IsAssignableFrom(buildertype))
            {
                Register<IContainerBuilder>(buildertype, "size", (b, bd) => b.WithBound(bd, _boundMapper));
                Register<IContainerBuilder>(buildertype, "height", (b, height) => b.WithHeight(height));
                Register<IContainerBuilder>(buildertype, "width", (b, width) => b.WithWidth(width));
                Register<IContainerBuilder>(buildertype, "selectablecontainer",
                                                 (b, isSelectableContainer) =>
                                                     b.IsSelectableContainer(isSelectableContainer, _booleanMapper));
            }
            if (typeof(IUIElementBuilder).IsAssignableFrom(buildertype))
            {
                Register<IUIElementBuilder>(buildertype, "backgroundcolor",
                                                 (b, c) => b.WithBackgroundColor(c, _colorMapper));
                Register<IUIElementBuilder>(buildertype, "backcolor",
                                                 (b, c) => b.WithBackgroundColor(c, _colorMapper));

                Register<IUIElementBuilder>(buildertype, "frontgroundcolor",
                                                 (b, c) => b.WithForegroundColor(c, _colorMapper));
                Register<IUIElementBuilder>(buildertype, "frontcolor",
                                                 (b, c) => b.WithForegroundColor(c, _colorMapper));

                Register<IUIElementBuilder>(buildertype, "border", (b, a) => b.WithBorder(a, _borderMapper));

                Register<IUIElementBuilder>(buildertype, "id", (b, id) => b.WithId(id));
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
            _builderMethods.Add((builderType, attributeName), (builder, arg) => builderMethod((T1)builder, (T2)arg));
        }
    }
}
