using System;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
        void Register<T>(string v1, string v2, Func<T,T> value);
    }
}
