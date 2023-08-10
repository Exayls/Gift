using Gift.SignalHandler;
using Gift.src.Services.Monitor.ConsoleMonitors;
using Gift.src.Services.SignalHandler.Ui;
using Gift.UI.DisplayManager;
using Gift.UI.MetaData;
using Moq;
using System;
using Xunit;

namespace TestGift.UnitTest.Event
{
    public class UiSignalHandlerTest
    {
        private ISignalHandler signalHandler;
        private Mock<IDisplayManager> _mockDisplayManger;
        private Mock<ISignal> _mockSignal;
        private Mock<EventArgs> _mockEventArgs;

        public UiSignalHandlerTest()
        {
            _mockDisplayManger = new Mock<IDisplayManager>();
            _mockSignal = new Mock<ISignal>();
            _mockEventArgs = new Mock<EventArgs>();
            signalHandler = new UISignalHandler(_mockDisplayManger.Object);
        }

        [Fact]
        public void When_sending_NextElement_signal_should_go_to_next_element_and_update_ui()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("Ui.NextElementInSelectedContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.NextElementInSelectedContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_PreviousElement_signal_should_go_to_previous_element_and_update_ui()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("Ui.PreviousElementInSelectedContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.NextElementInSelectedContainer(),Times.Never);
            _mockDisplayManger.Verify(dm => dm.PreviousElementInSelectedContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_resize_signal_should_resize_and_update_ui()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("Console.Resize");
            ConsoleSizeEventArgs evargs = new ConsoleSizeEventArgs(5, 5);
            _mockSignal.Setup(s => s.EventArgs ).Returns(evargs);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Resize(It.IsAny<Bound>()));
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_NextContainer_signal_should_go_to_next_Container_and_update_ui()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("Ui.NextContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.NextContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_PreviousContainer_signal_should_go_to_previous_Container_and_update_ui()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("Ui.PreviousContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.PreviousContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_random_signal_should_do_nothing()
        {
            //Arrange
            _mockSignal.Setup(s => s.Name ).Returns("ieuteieIEAsr");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.PreviousContainer(), Times.Never);
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay(), Times.Never);
        }
    }
}
