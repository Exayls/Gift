using Gift.Bus;
using Gift.SignalHandler;

namespace Gift.KeyInput
{
    public class KeyInputHandler
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
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    _signalBus.PushSignal(new Signal(consoleKeyInfo.ToString()?? "", EventArgs.Empty));
                    await Task.Delay(1);
                }
            }
        }
    }
}