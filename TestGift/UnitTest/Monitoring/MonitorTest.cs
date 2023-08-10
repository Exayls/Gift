using Gift.Monitor;
using Moq;
using Xunit;

namespace TestGift.UnitTest.Monitoring
{
    public class MonitorTest
    {
        private MonitorManager _monitorManager;

        public MonitorTest()
        {
            _monitorManager = new MonitorManager();
        }

        [Fact]
        public void When_adding_a_monitor_should_get_1_more_monitor()
        {
            Mock<IMonitor> monitorMock = new Mock<IMonitor>();
            _monitorManager.Add(monitorMock.Object);
            Assert.True(_monitorManager.Monitors.Contains(monitorMock.Object));
        }

        [Fact]
        public void When_deleting_a_monitor_should_delete_the_monitor()
        {
            Mock<IMonitor> monitorMock = new Mock<IMonitor>();
            _monitorManager.Add(monitorMock.Object);
            Assert.True(_monitorManager.Monitors.Contains(monitorMock.Object));
            _monitorManager.Remove(monitorMock.Object);
            Assert.False(_monitorManager.Monitors.Contains(monitorMock.Object));
        }
    }
}
