using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.Bus;
using Gift.KeyInput;
using Gift.Monitor;
using Gift.src.Services.Monitor;
using Gift.src.Services.SignalHandler.Key;
using Gift.src.Services.SignalHandler.Ui;
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

        private readonly ISignalBus _signalBus;

        private readonly IRenderer _renderer;
        private readonly IDisplayer _displayer;

        private readonly IGiftUiProvider _uiProvider;
        private readonly IDisplayManager _displayManager;

        private readonly IUISignalHandler _uiSignalHandler;
        private readonly IKeySignalHandler _keySignalHandler;

        private readonly IMonitorManager _monitorManager;//truc a faire avec ça. le keyInputHandler est un monitor
        private readonly IKeyInputHandler _keyInputHandler;
        private TaskCompletionSource<bool> _completionSource;
        public const char FILLINGCHAR = '*';

        public GiftBase(IRenderer renderer,
                        IDisplayer displayer,
                        IMonitorManager monitorManager,
                        ISignalBus queue,
                        IKeyInputHandler keyInputHandler,
                        IConsoleSizeMonitor consoleSizeMonitor,
                        IKeySignalHandler keySignalHandler,
                        IGiftUiProvider uiProvider,
                        IUISignalHandler uISignalHandler,
                        IDisplayManager displayManager)
        {
            _renderer = renderer;
            _displayer = displayer;
            _uiProvider = uiProvider;

            _signalBus = queue;
            _keyInputHandler = keyInputHandler;
            _keySignalHandler = keySignalHandler;

            _signalBus.Subscribe(_keySignalHandler);

            _displayManager = displayManager;
            _uiSignalHandler = uISignalHandler;

            _signalBus.Subscribe(_uiSignalHandler);

            _monitorManager = monitorManager;
            _monitorManager.Add(consoleSizeMonitor);

            _keyInputHandler.StartCheckUserInput();

            _completionSource = new TaskCompletionSource<bool>();

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
            _displayManager.UpdateDisplay();
        }

        public virtual async Task RunAsync()
        {
            await _completionSource.Task;
        }

        public void Stop()
        {
            _completionSource.SetResult(true);
        }
        public virtual void Run()
        {
             RunAsync().Wait();
        }

    }
}
