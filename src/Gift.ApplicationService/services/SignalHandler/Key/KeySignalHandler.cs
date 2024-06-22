using System;
using System.Collections.Generic;
using Gift.ApplicationService.Services.Monitor.KeyInteraction;
using Gift.ApplicationService.Services.SignalHandler.Bus;

namespace Gift.ApplicationService.Services.SignalHandler.Key
{
    public class KeySignalHandler : IKeySignalHandler
    {
        private readonly ISignalBus _bus;
        private readonly IList<IKeyMapping> _mappings;

        public KeySignalHandler(ISignalBus bus, IKeyMapper keyMapper)
        {
            _bus = bus;
            _mappings = keyMapper.GetMapping();
        }

        public void HandleSignal(ISignal signal)
        {
            if (signal.EventArgs is KeyEventArgs args && signal.Name == "KeyPressed")
            {
                KeyEventArgs eventsArgs = args;
                PushAllSignalMappedToKey(eventsArgs);
            }
        }

        private void PushAllSignalMappedToKey(KeyEventArgs eventsArgs)
        {
            foreach (IKeyMapping mapping in _mappings)
            {
                if (eventsArgs.KeyValue == mapping.KeyInfo.key && eventsArgs.Modifier == mapping.KeyInfo.modifiers)
                {
                    _bus.PushSignal(new Signal(mapping.SignalName, EventArgs.Empty));
                }
            }
        }
    }
}
