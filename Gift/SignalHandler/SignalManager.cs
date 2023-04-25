using Gift.UI;

namespace Gift.SignalHandler
{
    public class SignalManager : ISignalManager
    {
        public SignalManager()
        {
        }
        public void HandleSignal(ISignal signal, GiftUI ui)
        {
            if (signal.Name == "next")
            {
                ui.nextElement();
            }
        }
    }
}