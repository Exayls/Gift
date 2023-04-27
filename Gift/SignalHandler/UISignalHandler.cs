using Gift.Monitor;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.MetaData;

namespace Gift.SignalHandler
{
    public class UISignalHandler : ISignalHandler
    {
        public GiftUI Ui { get; }

        public UISignalHandler(GiftUI ui)
        {
            Ui = ui;
        }

        public void HandleSignal(ISignal signal)
        {
            switch (signal.Name)
            {
                case "UI.NextElement":
                    Ui.NextElementInSelectedContainer();
                    break;
                case "Console.Resize":
                    OnSizeChanged(signal.EventArgs);
                    break;
                default:
                    break;
            }
        }
        private void OnSizeChanged(EventArgs e)
        {
            ConsoleSizeEventArgs eventArgs = (ConsoleSizeEventArgs)e;
            Ui.Resize(new Bound(eventArgs.ConsoleHeight, eventArgs.ConsoleWidth));
        }
    }
}