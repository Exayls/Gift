using System;

namespace Gift.ApplicationService.services.FileParser
{
    public interface IUIElementRegister
    {
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
    }
}
