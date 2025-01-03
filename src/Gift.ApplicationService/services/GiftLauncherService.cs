using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.Domain.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler;
using Gift.Domain.UIModel.Element;
using System.Xml;
using System;
using System.Threading.Tasks;

namespace Gift.ApplicationService.Services
{
    public class GiftLauncherService : IGiftService
    {
        private readonly ISignalBus _signalBus;
        private readonly IRepository _repository;
        private readonly IDisplayService _displayService;
        private readonly IMonitorService _monitorService;
        private readonly IXMLFileParser _xmlParser;

        public GiftLauncherService(
            IMonitorService monitorManager,
            ISignalBus bus,
            IDisplayService displayService,
            IXMLFileParser xmlFileParser,
            IRepository repository)
        {
            _repository = repository;
            _displayService = displayService;

            _signalBus = bus;

            _monitorService = monitorManager;
            _monitorService.StartCheckingMonitors();

            _xmlParser = xmlFileParser;


        }

        public virtual void Initialize(UIElement ui)
        {
            _repository.SaveRoot(ui);
            Update();
        }

        public virtual void Initialize(string xmlPath)
        {
            _repository.SaveRoot(_xmlParser.ParseUIFile(xmlPath));
        }

        private void Update()
        {
            _displayService.UpdateDisplay();
        }

        public async void InitializeHotReload(string xmlPath)
        {
            while (true)
            {
                try
                {
                    await Task.Run(() =>
                                   {
                                       var root = _xmlParser.ParseUIFile(xmlPath);
                                       if (!root.IsSimilarTo(_repository.GetRoot()))
                                       {
                                           _repository.SaveRoot(root);
                                           Update();
                                       }
                                   });
                }
                catch (XmlException)
                {
                    await Task.Delay(100);
                }
                catch (Exception)
                {
                }
                await Task.Delay(20);
            }
        }

        public void AddSignalHandler(ISignalHandler handler)
        {
            _signalBus.Subscribe(handler);
        }

        public void AddMonitor(IMonitor keyInputMonitor)
        {
            _monitorService.Add(keyInputMonitor);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Update();
        }

        public void Stop()
        {
            Console.CursorVisible = true;
        }
    }
}
