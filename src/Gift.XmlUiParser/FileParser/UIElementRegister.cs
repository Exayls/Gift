using System;
using System.Collections.Generic;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Border;

namespace Gift.XmlUiParser.FileParser
{
    public class UIElementRegister : IUIElementRegister
    {
        private IDictionary<string, Type> _elements;
        private IDictionary<Tuple<Type, string>, Func<IUIElementBuilder, IUIElementBuilder>> _builderMethods;

        public UIElementRegister()
        {
            _elements = new Dictionary<string, Type>();
            _builderMethods = new Dictionary<Tuple<Type, string>, Func<IUIElementBuilder, IUIElementBuilder>>();


            this.Register<GiftUIBuilder>("GiftUI");
            this.Register<LabelBuilder>("Label");
            this.Register<VStackBuilder>("VStack");
            this.Register<HStackBuilder>("HStack");

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

        public void Register<T>(string name)
        {
            _elements.Add(name.ToLower(), typeof(T));

            this.Register<HStackBuilder, IBorder>("HStack", "border", (b, a) => b.WithBorder(a));
            this.Register<LabelBuilder>("Label", "text", (b, t) => b.WithText(t));
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
