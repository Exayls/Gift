using Xunit;
using Gift.Domain.UIModel;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;
using Gift.ApplicationService.Services;
using Gift.Domain.ServiceContracts;
using Moq;
using Gift.Domain.Builders;

namespace Gift.ApplicationService.Tests.Services
{
    public class GiftBaseTest
    {
        private readonly Mock<IRenderer> rendererMock;
        private readonly Mock<IDisplayer> displayerMock;
        private readonly Mock<IMonitorService> monitorManagerMock;
        private readonly Mock<ISignalBus> queueMock;
        private readonly Mock<IKeyMapper> keyMapperMock;
        private readonly Mock<IKeyInteractionMonitor> keyInputHandlerMock;
        private readonly Mock<IConsoleSizeMonitor> consoleSizeMonitorMock;
        private readonly Mock<IKeySignalHandler> keySignalHandlerMock;
        private readonly Mock<IGiftUiProvider> giftUiProviderMock;
        private readonly Mock<IUISignalHandler> uiSignalHandlerMock;
        private readonly Mock<IGlobalSignalHandler> globalSignalHandlerMock;
        private readonly Mock<IDisplayService> displayManagerMock;
        private readonly Mock<IXMLFileParser> xmlFileParserMock;
        private readonly Mock<IUIElementRegister> uIElementRegister;
        private readonly Mock<LifeTimeService> lifeTimeService;
        private readonly Mock<IRepository> repository;
        private readonly GiftLauncherService giftBase;

        public GiftBaseTest()
        {
            rendererMock = new Mock<IRenderer>();
            displayerMock = new Mock<IDisplayer>();
            monitorManagerMock = new Mock<IMonitorService>();
            queueMock = new Mock<ISignalBus>();
            keyMapperMock = new Mock<IKeyMapper>();
            keyInputHandlerMock = new Mock<IKeyInteractionMonitor>();
            consoleSizeMonitorMock = new Mock<IConsoleSizeMonitor>();
            keySignalHandlerMock = new Mock<IKeySignalHandler>();
            giftUiProviderMock = new Mock<IGiftUiProvider>();
            uiSignalHandlerMock = new Mock<IUISignalHandler>();
            globalSignalHandlerMock = new Mock<IGlobalSignalHandler>();
            displayManagerMock = new Mock<IDisplayService>();
            xmlFileParserMock = new Mock<IXMLFileParser>();
            uIElementRegister = new Mock<IUIElementRegister>();
            lifeTimeService = new Mock<LifeTimeService>();
            repository = new Mock<IRepository>();

            giftBase = new GiftLauncherService(
                monitorManager: monitorManagerMock.Object, bus: queueMock.Object,
                keyInputMonitor: keyInputHandlerMock.Object, consoleSizeMonitor: consoleSizeMonitorMock.Object,
                keySignalHandler: keySignalHandlerMock.Object, uiProvider: giftUiProviderMock.Object,
                uISignalHandler: uiSignalHandlerMock.Object, globalSignalHandler: globalSignalHandlerMock.Object,
                xmlFileParser: xmlFileParserMock.Object, elementRegister: uIElementRegister.Object,
                displayService: displayManagerMock.Object, lifeTimeService: lifeTimeService.Object,
                repository: repository.Object);
        }
    }
}
