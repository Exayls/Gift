using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.Monitor;
using Gift.SignalHandler;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.MetaData;

namespace Gift
{
    public class GiftBase
    {
        public GiftUI? Ui { get; set; }
        private readonly IRenderer _renderer;
        private readonly IDisplayer _displayer;
        private ISignalHandler? _signalManager;
        private readonly IMonitorManager _monitorManager;
        private readonly ISignalBus _signalQueue;
        public const char FILLINGCHAR = '*';


        public GiftBase(IRenderer? renderer = null, IDisplayer? displayer = null, IMonitorManager? monitorManager = null, ISignalBus? queue = null)
        {
            _renderer = renderer ?? new Renderer();
            _displayer = displayer ?? new ConsoleDisplayer();
            _monitorManager = monitorManager ?? new MonitorManager();
            _signalQueue = queue ?? new SignalBus();

            ConsoleSizeMonitor monitor = new ConsoleSizeMonitor(_signalQueue);
            _monitorManager.Add(monitor);
        }

        public virtual void Initialize()
        {
            Ui = new GiftUI();
            _signalManager =  new UISignalHandler(Ui);
            _signalQueue.Subscribe(_signalManager);
        }
        public virtual void Initialize(GiftUI ui)
        {
            this.Ui = ui;
            _signalManager =  new UISignalHandler(Ui);
            _signalQueue.Subscribe(_signalManager);
        }
        public virtual void Run()
        {
            while (true)
            {
                IScreenDisplay view = CreateView();
                PrintFrame(view);
                Thread.Sleep(1000);

                //_signalManager.HandleSignal(new Signal("next", EventArgs.Empty), Ui);
                _signalQueue.PushSignal(new Signal("UI.NextElement", EventArgs.Empty));
            }
        }


        public IScreenDisplay CreateView()
        {
            IScreenDisplay View = new ScreenDisplay(new Bound(0, 0));
            if (Ui != null)
            {
                View = _renderer.GetRenderDisplay(Ui);
            }
            return View;
        }
        private void PrintFrame(IScreenDisplay? View)
        {
            if (View != null)
            {
                _displayer.display(View);
            }
        }

        public virtual void End()
        {

        }

    }
}
