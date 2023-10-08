using System;

namespace Gift.ApplicationService.services.SignalHandler
{
    public interface ISignal
    {
        string Name { get; }
        EventArgs EventArgs { get; }
    }
}
