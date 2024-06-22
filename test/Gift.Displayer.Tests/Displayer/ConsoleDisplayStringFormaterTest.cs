using Gift.Displayer.Displayer;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Moq;
using Xunit;

namespace Gift.Displayer.Tests.Displayer
{
    public class ConsoleDisplayStringFormaterTest
    {
        private readonly ConsoleDisplayStringFormater formater;

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
            screenDisplay.Setup(s => s.TotalBound).Returns(new Size(2, 2));
            screenDisplay.Setup(s => s.DisplayMap).Returns(new char[,]
            {
                { '1', '2' },
                { '3', '4' }
            });
            screenDisplay.Setup(s => s.BackColorMap).Returns(new Color[,]
            {
                { Color.Magenta, Color.Black },
                { Color.Red, Color.Cyan }
            });
            screenDisplay.Setup(s => s.FrontColorMap).Returns(new Color[,]
            {
                { Color.Blue, Color.Green },
                { Color.White, Color.Yellow }
            });

            string displayString = formater.CreateDislayString(screenDisplay.Object);
            Assert.Equal("\u001b[45m\u001b[34m1\u001b[40m\u001b[32m2\n\u001b[41m\u001b[37m3\u001b[46m\u001b[33m4", displayString);
        }
    }
}
