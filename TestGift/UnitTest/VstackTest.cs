using Gift;
using Gift.UI;
using Gift.UI.Interface;
using Gift.UI.MetaData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest
{
    public class VstackTest
    {
        
        private Mock<IScreenDisplay> _screenDisplayMock;
        private Mock<IUIElement> _uiElementMock;
        private Mock<IBorder> _borderMock;
        private VStack vstack;

        public VstackTest()
        {
            _screenDisplayMock = new Mock<IScreenDisplay>();
            _uiElementMock = new Mock<IUIElement>();
            _borderMock = new Mock<IBorder>();
            vstack = new VStack(_borderMock.Object);
        }
        [Fact]
        public void GetDisplay_should_return_screen_when_call_GetDisplay_whithout_border()
        {
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(2, 4));
            //assert
            const string expected = "****\n"+
                                    "****";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }

        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border1()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("----\n").Append("-  -\n").Append("----"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.BorderChar).Returns('-');
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
            //assert
            const string expected = "----\n"+
                                    "-**-\n"+
                                    "----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border2()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("____\n").Append("_  _\n").Append("____"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.BorderChar).Returns('_');
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
            //assert
            const string expected = "____\n"+
                                    "_**_\n"+
                                    "____";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border3()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("iiii\n").Append("illi\n").Append("iiii"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.BorderChar).Returns('i');
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 4));
            //assert
            const string expected = "iiii\n"+
                                    "i**i\n"+
                                    "iiii";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border4()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("-----\n").Append("-   -\n").Append("-   -\n").Append("-   -\n").Append("-----"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.BorderChar).Returns('-');
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(5, 5));
            //assert
            const string expected = "-----\n"+
                                    "-***-\n"+
                                    "-***-\n"+
                                    "-***-\n"+
                                    "-----";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_screen_with_border_when_call_GetDisplay_with_border5()
        {
            //arrange
            _screenDisplayMock.Setup(s => s.DisplayString).Returns(new StringBuilder().Append("------\n").Append("-    -\n").Append("------"));
            _borderMock.Setup(b => b.Thickness).Returns(1);
            _borderMock.Setup(b => b.BorderChar).Returns('-');
            _borderMock.Setup(b => b.GetDisplay(It.IsAny<Bound>())).Returns(_screenDisplayMock.Object);
            vstack.Border = _borderMock.Object;
            //act
            IScreenDisplay screenDisplay = vstack.GetDisplay(new(3, 6));
            //assert
            const string expected = "------\n"+
                                    "-****-\n"+
                                    "------";
            Assert.Equal(expected, screenDisplay.DisplayString.ToString());
        }
    }
}
