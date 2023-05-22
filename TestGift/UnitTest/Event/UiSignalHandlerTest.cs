using Gift.Monitor;
using Gift.SignalHandler;
using Gift.UI;
using Gift.UI.DisplayManager;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGift.UnitTest.Event
{
    public class UiSignalHandlerTest
    {
        private ISignalHandler signalHandler;
        private Mock<IDisplayManager> _mockDisplayManger;
        private Mock<ISignal> _mockSignal;
        private Mock<EventArgs> _mockEventArgs;
        private Mock<IGiftUI> _mockUi;

        public UiSignalHandlerTest()
        {
            _mockDisplayManger = new Mock<IDisplayManager>();
            _mockUi = new Mock<IGiftUI>();
            _mockSignal = new Mock<ISignal>();
            _mockEventArgs = new Mock<EventArgs>();
            signalHandler = new UISignalHandler(_mockDisplayManger.Object);
        }

        [Fact]
        public void When_sending_NextElement_signal_should_go_to_next_element_and_update_ui()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("Ui.NextElementInSelectedContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.NextElementInSelectedContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_PreviousElement_signal_should_go_to_previous_element_and_update_ui()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("Ui.PreviousElementInSelectedContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.NextElementInSelectedContainer(),Times.Never);
            _mockDisplayManger.Verify(dm => dm.Ui.PreviousElementInSelectedContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_resize_signal_should_resize_and_update_ui()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("Console.Resize");
            ConsoleSizeEventArgs evargs = new ConsoleSizeEventArgs(5, 5);
            _mockSignal.Setup(s => s.EventArgs ).Returns(evargs);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.Resize(It.IsAny<Bound>()));
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_NextContainer_signal_should_go_to_next_Container_and_update_ui()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("Ui.NextContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.NextContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_PreviousContainer_signal_should_go_to_previous_Container_and_update_ui()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("Ui.PreviousContainer");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.PreviousContainer());
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay());
        }

        [Fact]
        public void When_sending_random_signal_should_do_nothing()
        {
            //Arrange
            _mockDisplayManger.Setup(dm => dm.Ui).Returns(_mockUi.Object);
            _mockSignal.Setup(s => s.Name ).Returns("ieuteieIEAsr");
            _mockSignal.Setup(s => s.EventArgs ).Returns(EventArgs.Empty);
            //Act
            signalHandler.HandleSignal(_mockSignal.Object);
            //Assert
            _mockDisplayManger.Verify(dm => dm.Ui.PreviousContainer(), Times.Never);
            _mockDisplayManger.Verify(dm => dm.UpdateDisplay(), Times.Never);
        }
    }
}
