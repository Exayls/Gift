using System;
using Gift.Domain.Builders;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        Type GetBuilder(string componentName);
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
        void Register<TBuilder>(string elementName, string attributeName, Func<TBuilder, string, TBuilder> builderMethod);
        void Register<TBuilder, TProduct>(string name) where TBuilder : IUIElementBuilder<TBuilder, TProduct>;
        void Register<T1, T2>(string elementName, string attributeName, Func<T1, T2, T1> BuilderMethod);
    }
}
