﻿using System;

namespace Gift.src.Services.FileParser
{
    public interface IUIElementRegister
    {
        Type GetTypeByName(string typeName);
        void Register(string name, Type type);
    }
}
