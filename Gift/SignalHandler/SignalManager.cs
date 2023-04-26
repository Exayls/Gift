using Gift.UI;

namespace Gift.SignalHandler
{
    public class SignalManager : ISignalManager
    {
        public GiftUI Ui { get; }

        public SignalManager(GiftUI ui)
        {
            Ui = ui;
        }

        public void HandleSignal(ISignal signal, GiftUI ui)
        {
            if (signal.Name == "next")
            {
                ui.nextElement();
            }
        }

        public void HandleSignal(ISignal signal)
        {
            if (signal.Name == "next")
            {
                Ui.nextElement();
            }
        }
    }
}