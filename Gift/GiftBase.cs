using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.Bus;
using Gift.KeyInput;
using Gift.Monitor;
using Gift.SignalHandler;
using Gift.SignalHandler.KeyInput;
using Gift.src.Services.Monitor;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.DisplayManager;
using Gift.UI.MetaData;
using Gift.UI.Render;

namespace Gift
{
    public class GiftBase
    {
        public GiftUI? Ui { get; set; }
        private readonly IRenderer _renderer;
        private readonly IDisplayer _displayer;
        private ISignalHandler? _uiSignalHandler;
        private ISignalHandler? _keySignalHandler;
        private readonly IMonitorManager _monitorManager;
        private readonly ISignalBus _signalBus;
        private IKeyInputHandler _keyInputHandler;
        private IDisplayManager? _displayManager;
        private IKeyMapper _keyMapper;
        public const char FILLINGCHAR = '*';


        public GiftBase(IRenderer renderer, IDisplayer displayer, IMonitorManager monitorManager, ISignalBus queue, IKeyMapper keyMapper, IKeyInputHandler keyInputHandler, IConsoleSizeMonitor consoleSizeMonitor)
        {
            _renderer = renderer;
            _displayer = displayer;
            _monitorManager = monitorManager;
            _signalBus = queue;
            _keyMapper =keyMapper;
            _keyInputHandler = keyInputHandler;
            _monitorManager.Add(consoleSizeMonitor);
        }

        public virtual void Initialize(GiftUI? ui = null)
        {
            this.Ui = ui ?? new GiftUI();
            init();
        }
        private void init()
        {
            _displayManager = new DisplayManager(_displayer, _renderer, Ui);

            _uiSignalHandler =  new UISignalHandler(_displayManager);
            _keySignalHandler =  new KeySignalHandler(_signalBus, _keyMapper);

            _signalBus.Subscribe(_uiSignalHandler);
            _signalBus.Subscribe(_keySignalHandler);

            _keyInputHandler.StartCheckUserInput();

            _displayManager.UpdateDisplay();

        }

        public virtual void Run()
        {
            while (true)
            {
            }
        }

    }
}
