using System.Threading.Tasks;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Element;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;
using Gift.Domain.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler;

namespace Gift.ApplicationService.Services
{
    public class GiftLauncherService : IGiftLauncherService
    {
        public GiftUI Ui
        {
            get
            {
                return _uiProvider.Ui;
            }
        }

        private readonly ISignalBus _signalBus;

        private readonly IGiftUiProvider _uiProvider;


        private readonly IUISignalHandler _uiSignalHandler;
        private readonly IKeySignalHandler _keySignalHandler;
        private readonly IGlobalSignalHandler _globalSignalHandler;

        private readonly IDisplayService _displayService;
        private readonly IMonitorService _monitorService;

        private readonly IXMLFileParser _xmlParser;
        private readonly IUIElementRegister _uielementRegister;

        private TaskCompletionSource<bool> completion;
        private ILifeTimeService _lifeTimeService;
        public const char FILLINGCHAR = '*';

        public GiftLauncherService(
                        IMonitorService monitorManager,
                        ISignalBus queue,
                        IKeyInputMonitor keyInputHandler,
                        IConsoleSizeMonitor consoleSizeMonitor,
                        IKeySignalHandler keySignalHandler,
                        IGiftUiProvider uiProvider,
                        IUISignalHandler uISignalHandler,
                        IGlobalSignalHandler globalSignalHandler,
                        IDisplayService displayManager,
                        IXMLFileParser xmlFileParser,
                        IUIElementRegister elementRegister,
                        ILifeTimeService lifeTimeService)
        {
            _uiProvider = uiProvider;
            _displayService = displayManager;

            _signalBus = queue;

            _keySignalHandler = keySignalHandler;
            _signalBus.Subscribe(_keySignalHandler);

            _uiSignalHandler = uISignalHandler;
            _signalBus.Subscribe(_uiSignalHandler);

            _globalSignalHandler = globalSignalHandler;
            _signalBus.Subscribe(_globalSignalHandler);

            _monitorService = monitorManager;
            _monitorService.Add(consoleSizeMonitor);
            _monitorService.Add(keyInputHandler);

            _monitorService.StartCheckingMonitors();

            _xmlParser = xmlFileParser;

            _uielementRegister = elementRegister;
            RegisterUIElements();

            _lifeTimeService = lifeTimeService;
        }

        private void RegisterUIElements()
        {
            _uielementRegister.Register("GiftUI", typeof(GiftUI));
            _uielementRegister.Register("VStack", typeof(VStack));
            _uielementRegister.Register("HStack", typeof(HStack));
            _uielementRegister.Register("Label", typeof(Label));
        }

        public virtual void Initialize(GiftUI ui)
        {
            _uiProvider.Ui = ui;
            update();
        }

        public virtual void Initialize(string xmlPath)
        {
            _uiProvider.Ui = _xmlParser.ParseUIFile(xmlPath);
            update();
        }

        private void update()
        {
            _displayService.UpdateDisplay();
        }
        public async void InitializeHotReload(string file)
        {
            while (true)
            {
                await Task.Run(() => Initialize(file));
            }
        }



        public void AddSignalHandler(ISignalHandlerService handler)
        {
            throw new System.NotImplementedException();
        }

        public void Run()
        {
            _lifeTimeService.Run();
        }

        public void Stop()
        {
            _lifeTimeService.Stop();
        }
    }
}
