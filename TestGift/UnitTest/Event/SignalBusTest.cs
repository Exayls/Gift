using Gift.SignalHandler;
using Gift.src.Services.SignalHandler.Bus;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGift.Test.Event
{
    public class SignalBusTest
    {
        ISignalBus bus;
        Mock<ISignal> _mockSignal;
        private Mock<ISignalHandler> _mockSubscriber;

        public SignalBusTest()
        {
            bus = new SignalBus();
            _mockSignal = new Mock<ISignal>();
            _mockSubscriber = new Mock<ISignalHandler>();
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
