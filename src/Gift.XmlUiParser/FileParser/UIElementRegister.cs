using System;
using System.Collections.Generic;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;

namespace Gift.XmlUiParser.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private IDictionary<string, Type> _elements;
        private Dictionary<(Type builderType, string attribute), Func<IBuilder<UIElement>, object, IBuilder<UIElement>>> _builderMethods;


        public UIElementRegister()
        {
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
            return _builderMethods[(typeof(Builder), attribute)];
        }

        public Func<IBuilder<UIElement>, object, IBuilder<UIElement>> GetMethod(Type builder, string attribute)
        {
            return _builderMethods[(builder, attribute)];
        }

        public void Register(string name, Type type)
        {
            _elements.Add(name.ToLower(), type);
        }

        public void Register<TBuilder>(string name)
            where TBuilder : IUIElementBuilder
        {
            _elements.Add(name.ToLower(), typeof(TBuilder));

            if (typeof(TBuilder) is IContainerBuilder)
            {
                //TODO
            }
            if (typeof(TBuilder) is IUIElementBuilder)
            {
                this.Register<IUIElementBuilder, IBorder>("border", (b, a) => b.WithBorder(a));
            }
        }


        public void Register<T>(string attributeName, Func<T, string, T> builderMethod)
            where T : IUIElementBuilder
        {
            Register<T, string>(attributeName, builderMethod);
        }

        public void Register<T1, T2>(string attributeName, Func<T1, T2, T1> builderMethod)
            where T1 : IUIElementBuilder
        {
            // _builderMethods.Add((typeof(T1), elementName), builderMethod);
            _builderMethods.Add(
                    (typeof(T1), attributeName),
                    (builder, arg) => builderMethod((T1)builder, (T2)arg)
                );
        }
    }
}
