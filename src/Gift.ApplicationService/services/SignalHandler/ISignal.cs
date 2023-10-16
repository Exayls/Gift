using System;

namespace Gift.ApplicationService.Services.SignalHandler
{
    public interface ISignal
    {
        string Name { get; }
        EventArgs EventArgs { get; }
    }
}
