using System;

namespace Gift.Domain.ServiceContracts
{
    public interface IUIElementRegister
    {
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
    }
}
