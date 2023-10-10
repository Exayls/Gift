using Moq;
using Xunit;
using Gift.Domain.UIModel;
using Gift.ApplicationService.Services.SignalHandler.Global;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Gift.ApplicationService.ServiceContracts;
using Gift.ApplicationService.Services.SignalHandler.Ui;
using Gift.ApplicationService.Services.SignalHandler.Key;
using Gift.ApplicationService.Services;
using Gift.Domain.ServiceContracts;

namespace TestGift.UnitTest.Base
{
    public class GiftBaseTest
    {
        private Mock<IRenderer> rendererMock;
        private Mock<IDisplayer> displayerMock;
        private Mock<IMonitorService> monitorManagerMock;
        private Mock<ISignalBus> queueMock;
        private Mock<IKeyMapper> keyMapperMock;
        private Mock<IKeyInteractionMonitor> keyInputHandlerMock;
        private Mock<IConsoleSizeMonitor> consoleSizeMonitorMock;
        private Mock<IKeySignalHandler> keySignalHandlerMock;
        private Mock<IGiftUiProvider> giftUiProviderMock;
        private Mock<IUISignalHandler> uiSignalHandlerMock;
        private Mock<IGlobalSignalHandler> globalSignalHandlerMock;
        private Mock<IDisplayService> displayManagerMock;
        private Mock<IXMLFileParser> xmlFileParserMock;
        private Mock<IUIElementRegister> uIElementRegister;
        private Mock<LifeTimeService> lifeTimeService;
        private GiftLauncherService giftBase;

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


            giftBase = new GiftLauncherService(
                           monitorManager: monitorManagerMock.Object,
                           queue: queueMock.Object,
                           keyInputHandler: keyInputHandlerMock.Object,
                           consoleSizeMonitor: consoleSizeMonitorMock.Object,
                           keySignalHandler: keySignalHandlerMock.Object,
                           uiProvider: giftUiProviderMock.Object,
                           uISignalHandler: uiSignalHandlerMock.Object,
                           globalSignalHandler: globalSignalHandlerMock.Object,
                           xmlFileParser: xmlFileParserMock.Object,
                           elementRegister: uIElementRegister.Object,
                           displayManager: displayManagerMock.Object,
                           lifeTimeService: lifeTimeService.Object
                           );
        }

        [Fact]
        public void should_return_provider_ui()
        {
            GiftUI giftUI = new GiftUI();
            giftUiProviderMock.Setup(p => p.Ui).Returns(giftUI);
            Assert.Equal(giftUI, giftBase.Ui);
        }

        [Fact]
        public void When_initialized_should_set_ui()
        {
            GiftUI uiMock = GetGiftUI();
            giftBase.Initialize(uiMock);
            giftUiProviderMock.VerifySet(p => p.Ui = uiMock);
        }

        private static GiftUI GetGiftUI()
        {
            return new GiftUI();
        }
    }
}
