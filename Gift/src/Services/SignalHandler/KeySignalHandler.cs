using Gift.Builders;
using Gift.Bus;
using Gift.KeyInput;
using Gift.SignalHandler.KeyInput;
using Gift.UI;
using Gift.UI.DisplayManager;

namespace Gift.SignalHandler
{
    internal class KeySignalHandler : ISignalHandler
    {
        private ISignalBus _bus;
        private IKeyMapper _keyMapper;
        private IList<IKeyMapping> _mappings;

        public KeySignalHandler(ISignalBus bus, IKeyMapper keyMapper)
        {
            _bus = bus;
            _keyMapper = keyMapper;
            _mappings = _keyMapper.GetMapping();
        }

        public void HandleSignal(ISignal signal)
        {
            if (signal.EventArgs is KeyEventArgs)
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