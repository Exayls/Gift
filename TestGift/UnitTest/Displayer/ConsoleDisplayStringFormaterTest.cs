using Gift.src.Services.Displayer;
using Gift.UI.Display;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestGift.UnitTest.Displayer
{
    public class ConsoleDisplayStringFormaterTest
    {
        private ConsoleDisplayStringFormater formater;

        public ConsoleDisplayStringFormaterTest()
        {
            formater = new ConsoleDisplayStringFormater();
        }

        [Fact]
        public void When_screenDisplay_is_empty_should_return_empty_string()
        {
            Mock<IScreenDisplay> screenDisplay = new Mock<IScreenDisplay>();

            string displayString = formater.CreateDislayString(screenDisplay.Object);
            Assert.Equal("", displayString);
        }

        [Fact]
        public void Should_return_string_based_on_screenDisplay()
        {
            Mock<IScreenDisplay> screenDisplay = new Mock<IScreenDisplay>();

            string displayString = formater.CreateDislayString(screenDisplay.Object);
            Assert.Equal("", displayString);
        }
    }
}
