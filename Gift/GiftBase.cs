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
using Gift.src.UIModel;
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
        public IGiftUI Ui
        {
            get
            {
                return _uiProvider.Ui;
            }
        }
        private readonly IRenderer _renderer;
        private readonly IDisplayer _displayer;
        private readonly IGiftUiProvider _uiProvider;
        private ISignalHandler? _uiSignalHandler;
        private IKeySignalHandler _keySignalHandler;
        private readonly IMonitorManager _monitorManager;
        private readonly ISignalBus _signalBus;
        private readonly IKeyInputHandler _keyInputHandler;
        private IDisplayManager? _displayManager;
        public const char FILLINGCHAR = '*';


        public GiftBase(IRenderer renderer, IDisplayer displayer, IMonitorManager monitorManager, ISignalBus queue, IKeyInputHandler keyInputHandler, IConsoleSizeMonitor consoleSizeMonitor, IKeySignalHandler keySignalHandler, IGiftUiProvider uiProvider, IUISignalHandler uISignalHandler)
        {
            _renderer = renderer;
            _displayer = displayer;
            _uiProvider = uiProvider;

            _signalBus = queue;
            _keyInputHandler = keyInputHandler;
            _keySignalHandler = keySignalHandler;

            _signalBus.Subscribe(_keySignalHandler);

            _displayManager = new DisplayManager(_displayer, _renderer, _uiProvider);
            _uiSignalHandler = uISignalHandler;

            _signalBus.Subscribe(_uiSignalHandler);

            _monitorManager = monitorManager;
            _monitorManager.Add(consoleSizeMonitor);

            _keyInputHandler.StartCheckUserInput();

            _displayManager.UpdateDisplay();
        }

        public virtual void Initialize(IGiftUI? ui = null)
        {
            if (ui != null)
            {
                this._uiProvider.Ui = ui;
            }
            init();
        }
        private void init()
        {

        }

        public virtual void Run()
        {
            while (true)
            {
            }
        }

    }
}
