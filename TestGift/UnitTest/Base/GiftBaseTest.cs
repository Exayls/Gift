using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gift.UI.Render;
using Gift.KeyInput;
using Gift.Monitor;
using Gift.UI.Displayer;
using Xunit;
using Gift.src.UIModel;
using Gift.src.Extensions;
using Gift.UI;
using Gift.UI.DisplayManager;
using Gift.src.Services.SignalHandler.Key;
using Gift.src.Services.SignalHandler.Ui;
using Gift.src.Services.Monitor.ConsoleMonitors;
using Gift.src.Services.SignalHandler.Bus;

namespace TestGift.LifeCycle
{
    public class GiftBaseTest
    {
        private Mock<IRenderer> rendererMock;
        private Mock<IDisplayer> displayerMock;
        private Mock<IMonitorManager> monitorManagerMock;
        private Mock<ISignalBus> queueMock;
        private Mock<IKeyMapper> keyMapperMock;
        private Mock<IKeyInputHandler> keyInputHandlerMock;
        private Mock<IConsoleSizeMonitor> consoleSizeMonitorMock;
        private Mock<IKeySignalHandler> keySignalHandlerMock;
        private Mock<IGiftUiProvider> giftUiProviderMock;
        private Mock<IUISignalHandler> uiSignalHandlerMock;
        private Mock<IDisplayManager> displayManagerMock;

        public GiftBaseTest()
        {
            rendererMock = new Mock<IRenderer>();
            displayerMock = new Mock<IDisplayer>();
            monitorManagerMock = new Mock<IMonitorManager>();
            queueMock = new Mock<ISignalBus>();
            keyMapperMock = new Mock<IKeyMapper>();
            keyInputHandlerMock = new Mock<IKeyInputHandler>();
            consoleSizeMonitorMock = new Mock<IConsoleSizeMonitor>();
            keySignalHandlerMock = new Mock<IKeySignalHandler>();
            giftUiProviderMock = new Mock<IGiftUiProvider>();
            uiSignalHandlerMock = new Mock<IUISignalHandler>();
            displayManagerMock = new Mock<IDisplayManager>();
        }

        [Fact]
        public void should_return_provider_ui()
        {
            Mock<IGiftUI> uiMock = new Mock<IGiftUI>();
            giftUiProviderMock.Setup(p => p.Ui).Returns(uiMock.Object);

            var giftBase = new GiftBase(
                           rendererMock.Object,
                           displayerMock.Object,
                           monitorManagerMock.Object,
                           queueMock.Object,
                           keyInputHandlerMock.Object,
                           consoleSizeMonitorMock.Object,
                           keySignalHandlerMock.Object,
                           giftUiProviderMock.Object,
                           uiSignalHandlerMock.Object,
                           displayManagerMock.Object);

            Assert.Equal(uiMock.Object, giftBase.Ui);
        }

        [Fact]
        public void When_initialized_should_set_ui()
        {
            Mock<IGiftUI> uiMock = new Mock<IGiftUI>();

            var giftBase = new GiftBase(
                           rendererMock.Object,
                           displayerMock.Object,
                           monitorManagerMock.Object,
                           queueMock.Object,
                           keyInputHandlerMock.Object,
                           consoleSizeMonitorMock.Object,
                           keySignalHandlerMock.Object,
                           giftUiProviderMock.Object,
                           uiSignalHandlerMock.Object,
                           displayManagerMock.Object);
            giftBase.Initialize(uiMock.Object);

            giftUiProviderMock.VerifySet(p => p.Ui = uiMock.Object);
        }
    }
}
