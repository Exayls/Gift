using System;
using System.Collections.Generic;
using Gift.Domain.Builders;
using Gift.Domain.ServiceContracts;

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
        }

        public void Register<T>(string elementName, string attributeName, Func<T, T> BuilderMethod)
        {
            throw new NotImplementedException();
        }

        public void Register<T1, T2>(string elementName, string attributeName, Func<T1, T1> BuilderMethod)
        {
            throw new NotImplementedException();
        }
    }
}
