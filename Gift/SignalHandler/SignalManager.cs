using Gift.UI;

namespace Gift.SignalHandler
{
    internal class SignalManager : ISignalManager
    {
        public SignalManager()
        {
            var a = new Signal("itesauir");
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