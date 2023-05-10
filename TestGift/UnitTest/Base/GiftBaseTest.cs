using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gift.UI.Render;
using Gift.src.Services.Monitor;
using Gift.KeyInput;
using Gift.SignalHandler.KeyInput;
using Gift.Bus;
using Gift.Monitor;
using Gift.UI.Displayer;

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

        public GiftBaseTest()
        {
            rendererMock = new Mock<IRenderer>();
            displayerMock = new Mock<IDisplayer>();
            monitorManagerMock = new Mock<IMonitorManager>();
            queueMock = new Mock<ISignalBus>();
            keyMapperMock = new Mock<IKeyMapper>();
            keyInputHandlerMock = new Mock<IKeyInputHandler>();
            consoleSizeMonitorMock = new Mock<IConsoleSizeMonitor>();
        }
        [Fact]
        public void When_not_initialized_should_not_set_ui()
        {
            var giftBase = new GiftBase(
                           rendererMock.Object,
                           displayerMock.Object,
                           monitorManagerMock.Object,
                           queueMock.Object,
                           keyMapperMock.Object,
                           keyInputHandlerMock.Object,
                           consoleSizeMonitorMock.Object
                       );

            Assert.True(giftBase.Ui == null);

        }
        [Fact]
        public void When_initialized_should_set_ui()
        {
            var giftBase = new GiftBase(
                           rendererMock.Object,
                           displayerMock.Object,
                           monitorManagerMock.Object,
                           queueMock.Object,
                           keyMapperMock.Object,
                           keyInputHandlerMock.Object,
                           consoleSizeMonitorMock.Object
                       );
            giftBase.Initialize();

            Assert.True(giftBase.Ui != null);

        }
    }
}
