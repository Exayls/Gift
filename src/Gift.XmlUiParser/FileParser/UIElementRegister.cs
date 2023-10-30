using System;
using System.Collections.Generic;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;

namespace Gift.XmlUiParser.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private IDictionary<string, Type> _elements;
        // private IDictionary<Tuple<Type, string>, Func<IUIElementBuilder, IUIElementBuilder>> _builderMethods;

        public UIElementRegister()
        {
            _elements = new Dictionary<string, Type>();
            // _builderMethods = new Dictionary<Tuple<Type, string>, Func<IUIElementBuilder, IUIElementBuilder>>();


            this.Register<GiftUIBuilder, GiftUI>("GiftUI");
            this.Register<LabelBuilder, Label>("Label");
            this.Register<VStackBuilder, VStack>("VStack");
            this.Register<HStackBuilder, HStack>("HStack");

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

        public Type GetTypeByName(string typeName)
        {
            string key = typeName.ToLower();
            if (!_elements.ContainsKey(key))
            {
                throw new NotSupportedException("Unknown component: " + typeName);
            }
            return _elements[key];
        }

        public void Register(string name, Type type)
        {
            _elements.Add(name.ToLower(), type);
        }

        public void Register<TBuilder, TProduct>(string name)
            where TBuilder : IBuilder<TProduct>
        {
            _elements.Add(name.ToLower(), typeof(TBuilder));

            if (typeof(TBuilder) is IContainerBuilder<Container>)
            {
                //TODO
            }
            if (typeof(TBuilder) is IUIElementBuilder<UIElement>)
            {
                this.Register<IUIElementBuilder<UIElement>, IBorder>(name.ToLower(), "border", (b, a) => b.WithBorder(a));
            }
        }


        public void Register<T>(string elementName, string attributeName, Func<T, string, T> BuilderMethod)
        {
            throw new NotImplementedException();
        }

        public void Register<T1, T2>(string elementName, string attributeName, Func<T1, T2, T1> BuilderMethod)
        {
            var a = typeof(T1);
            var b = typeof(T2);
            Console.WriteLine(typeof(T1));
        }

    }
}
