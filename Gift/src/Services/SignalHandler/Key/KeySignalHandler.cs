using Gift.Builders;
using Gift.KeyInput;
using Gift.SignalHandler;
using Gift.src.Services.SignalHandler.Bus;
using Gift.UI;
using Gift.UI.DisplayManager;

namespace Gift.src.Services.SignalHandler.Key
{
    public class KeySignalHandler : IKeySignalHandler
    {
        private ISignalBus _bus;
        private IList<IKeyMapping> _mappings;

        public KeySignalHandler(ISignalBus bus, IKeyMapper keyMapper)
        {
            _bus = bus;
            _mappings = keyMapper.GetMapping();
        }

        public void HandleSignal(ISignal signal)
        {
            if (signal.EventArgs is KeyEventArgs && signal.Name == "KeyPressed")
            {
                KeyEventArgs eventsArgs = (KeyEventArgs)signal.EventArgs;
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