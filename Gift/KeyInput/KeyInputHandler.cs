using Gift.Bus;
using Gift.SignalHandler;

namespace Gift.KeyInput
{
    public class KeyInputHandler : IKeyInputHandler
    {
        private ISignalBus _signalBus;
        public KeyInputHandler(ISignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public async void StartCheckUserInput()
        {
            while (true)
            {
                await Task.Delay(1);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    string keyValue = consoleKeyInfo.Key.ToString();
                    _signalBus.PushSignal(new Signal(keyValue ?? "", EventArgs.Empty));
                }
            }
        }
    }
}