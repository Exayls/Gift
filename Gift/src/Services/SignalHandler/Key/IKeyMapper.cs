﻿namespace Gift.src.Services.SignalHandler.Key
{
    public interface IKeyMapper
    {
        IList<IKeyMapping> GetMapping();
    }
}