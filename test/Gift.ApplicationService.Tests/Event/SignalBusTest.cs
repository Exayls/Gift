using Gift.ApplicationService.Services.SignalHandler;
using Gift.ApplicationService.Services.SignalHandler.Bus;
using Moq;
using Xunit;

namespace Gift.ApplicationService.Tests.Event
{
    public class SignalBusTest
    {
        ISignalBus bus;
        Mock<ISignal> _mockSignal;
        private Mock<ISignalHandlerService> _mockSubscriber;

        public SignalBusTest()
        {
            bus = new SignalBus();
            _mockSignal = new Mock<ISignal>();
            _mockSubscriber = new Mock<ISignalHandlerService>();
        }

        [Fact]
        public void When_Pushing_signal_should_trigger_bus_subscribers()
        {
            bus.Subscribe(_mockSubscriber.Object);
            bus.PushSignal(_mockSignal.Object);

            //assert
            _mockSubscriber.Verify(s => s.HandleSignal(_mockSignal.Object));
        }
    }
}
