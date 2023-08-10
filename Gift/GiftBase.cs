using System.Threading.Tasks;
using Gift.KeyInput;
using Gift.Monitor;
using Gift.src.Services.FileParser;
using Gift.src.Services.Monitor.ConsoleMonitors;
using Gift.src.Services.SignalHandler.Bus;
using Gift.src.Services.SignalHandler.Global;
using Gift.src.Services.SignalHandler.Key;
using Gift.src.Services.SignalHandler.Ui;
using Gift.src.UIModel;
using Gift.UI;
using Gift.UI.Displayer;
using Gift.UI.DisplayManager;
using Gift.UI.Element;
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
        private readonly IGlobalSignalHandler _globalSignalHandler;

        private readonly IMonitorManager _monitorManager;//truc a faire avec ça. le keyInputHandler est un monitor
        private readonly IKeyInputHandler _keyInputHandler;

        private readonly IXMLFileParser _xmlParser;
        private readonly IUIElementRegister _uielementRegister;
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
                        IGlobalSignalHandler globalSignalHandler,
                        IXMLFileParser xmlFileParser,
                        IDisplayManager displayManager,
                        IUIElementRegister elementRegister)
        {
            _renderer = renderer;
            _displayer = displayer;
            _uiProvider = uiProvider;
            _displayManager = displayManager;

            _signalBus = queue;
            _keyInputHandler = keyInputHandler;

            _keySignalHandler = keySignalHandler;
            _signalBus.Subscribe(_keySignalHandler);

            _uiSignalHandler = uISignalHandler;
            _signalBus.Subscribe(_uiSignalHandler);

            _globalSignalHandler = globalSignalHandler;
            _signalBus.Subscribe(_globalSignalHandler);

            _monitorManager = monitorManager;
            _monitorManager.Add(consoleSizeMonitor);

            _monitorManager.StartCheckingMonitors();
            _keyInputHandler.StartCheckUserInput();

            _xmlParser = xmlFileParser;

            _uielementRegister = elementRegister;
            RegisterUIElements();
        }

        private void RegisterUIElements()
        {
            _uielementRegister.Register("GiftUI", typeof(GiftUI));
            _uielementRegister.Register("VStack", typeof(VStack));
            _uielementRegister.Register("HStack", typeof(HStack));
            _uielementRegister.Register("Label",  typeof(Label));
        }

        public virtual void Initialize(IGiftUI ui)
        {
            _uiProvider.Ui = ui;
            init();
        }

        public virtual void Initialize(string xmlPath)
        {
            _uiProvider.Ui = _xmlParser.ParseUIFile(xmlPath);
            init();
        }

        private void init()
        {
            _displayManager.UpdateDisplay();
        }

        public virtual async Task RunAsync()
        {
            await _globalSignalHandler.Completion.Task;
        }

        public virtual void Run()
        {
            RunAsync().Wait();
        }

        public async void InitializeHotReload(string file)
        {
            while (true)
            {
                await Task.Run(() => Initialize(file));
            }
        }
    }
}
