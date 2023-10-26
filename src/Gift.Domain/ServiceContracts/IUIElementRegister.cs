using System;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
        void Register<T>(string elementName, string attributeName, Func<T, string, T> builderMethod);
        void Register<T>(string v);
        void Register<T1, T2>(string elementName, string attributeName, Func<T1, T2, T1> BuilderMethod);
    }
}
