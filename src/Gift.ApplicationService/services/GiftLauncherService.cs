using System.Threading.Tasks;
using Gift.Domain.UIModel;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;
using Gift.Domain.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler;

namespace Gift.ApplicationService.Services
{
    public class GiftLauncherService : IGiftService
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
        private readonly IDisplayService _displayService;
        private readonly IMonitorService _monitorService;
        private readonly IXMLFileParser _xmlParser;
        private readonly IUIElementRegister _uielementRegister;
        private readonly ILifeTimeService _lifeTimeService;

        public const char FILLINGCHAR = '*';

        public GiftLauncherService(
                        IMonitorService monitorManager,
                        ISignalBus bus,
                        IKeyInteractionMonitor keyInputMonitor,
                        IConsoleSizeMonitor consoleSizeMonitor,
                        IKeySignalHandler keySignalHandler,
                        IGiftUiProvider uiProvider,
                        IUISignalHandler uISignalHandler,
                        IGlobalSignalHandler globalSignalHandler,
                        IDisplayService displayService,
                        IXMLFileParser xmlFileParser,
                        IUIElementRegister elementRegister,
                        ILifeTimeService lifeTimeService)
        {
            _uiProvider = uiProvider;
            _displayService = displayService;

            _signalBus = bus;

            _signalBus.Subscribe(keySignalHandler);
            _signalBus.Subscribe(uISignalHandler);
            _signalBus.Subscribe(globalSignalHandler);

            _monitorService = monitorManager;
            _monitorService.Add(consoleSizeMonitor);
            _monitorService.Add(keyInputMonitor);
            _monitorService.StartCheckingMonitors();

            _xmlParser = xmlFileParser;

            _uielementRegister = elementRegister;

            _lifeTimeService = lifeTimeService;
        }


        public virtual void Initialize(GiftUI ui)
        {
            _uiProvider.Ui = ui;
            update();
        }

        public virtual void Initialize(string xmlPath)
        {
            _uiProvider.Ui = (GiftUI)_xmlParser.ParseUIFileUsingBuilders(xmlPath);
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
            _signalBus.Subscribe(handler);
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
