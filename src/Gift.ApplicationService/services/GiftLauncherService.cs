using System.Threading.Tasks;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;
using Gift.Domain.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.UIModel.Element;
using System.Xml;
using System.Threading;

namespace Gift.ApplicationService.Services
{
    public class GiftLauncherService : IGiftService
    {
        private readonly ISignalBus _signalBus;
        private readonly IRepository _repository;
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
            IUISignalHandler uISignalHandler,
            IGlobalSignalHandler globalSignalHandler,
            IDisplayService displayService,
            IXMLFileParser xmlFileParser,
            IUIElementRegister elementRegister,
            ILifeTimeService lifeTimeService,
            IRepository repository)
        {
            _repository = repository;
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

        public virtual void Initialize(UIElement ui)
        {
            _repository.SaveRoot(ui);
            update();
        }

        public virtual void Initialize(string xmlPath)
        {
            _repository.SaveRoot(_xmlParser.ParseUIFile(xmlPath));
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
                try
                {
                    await Task.Run(() => Initialize(file));
                }
                catch (XmlException)
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(20);
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
