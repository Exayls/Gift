using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.Border
{
    public class SimpleBorderTest
    {
        private SimpleBorder SimpleBorder;

        public SimpleBorderTest()
        {
            SimpleBorder = new SimpleBorder(1, '/');
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_1()
        {
            //act
            Bound bound = new Bound(2, 2);
			var screen = new ScreenDisplayBuilder().WithBound(bound);
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "//\n" +
                                    "//";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_2()
        {
            Bound bound = new Bound(4, 4);
			var screen = new ScreenDisplayBuilder().WithBound(bound).WithChar(' ');
            //act
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "////\n" +
                                    "/  /\n" +
                                    "/  /\n" +
                                    "////";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_3()
        {
            //arrange
            SimpleBorder = new SimpleBorder(1, '»');
            Bound bound = new Bound(4, 4);
			var screen = new ScreenDisplayBuilder().WithBound(bound).WithChar(' ');
            //act
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "»»»»\n" +
                                    "»  »\n" +
                                    "»  »\n" +
                                    "»»»»";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_greater_than_1_1()
        {
            //arrange
            SimpleBorder = new SimpleBorder(2, '»');
            Bound bound = new Bound(6, 6);
			var screen = new ScreenDisplayBuilder().WithBound(bound).WithChar(' ');
            //act
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "»»»»»»\n" +
                                    "»»»»»»\n" +
                                    "»»  »»\n" +
                                    "»»  »»\n" +
                                    "»»»»»»\n" +
                                    "»»»»»»";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_greater_than_1_2()
        {
            //arrange
            SimpleBorder = new SimpleBorder(2, '»');
            Bound bound = new Bound(8, 8);
			var screen = new ScreenDisplayBuilder().WithBound(bound).WithChar(' ');
            //act
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "»»»»»»»»\n" +
                                    "»»»»»»»»\n" +
                                    "»»    »»\n" +
                                    "»»    »»\n" +
                                    "»»    »»\n" +
                                    "»»    »»\n" +
                                    "»»»»»»»»\n" +
                                    "»»»»»»»»";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_greater_than_1_3()
        {
            //arrange
            SimpleBorder = new SimpleBorder(3, '»');
            Bound bound = new Bound(8, 8);
			var screen = new ScreenDisplayBuilder().WithBound(bound).WithChar(' ');
            //act
            IScreenDisplay display = SimpleBorder.GetDisplay(screen);
            //assert
            const string expected = "»»»»»»»»\n" +
                                    "»»»»»»»»\n" +
                                    "»»»»»»»»\n" +
                                    "»»»  »»»\n" +
                                    "»»»  »»»\n" +
                                    "»»»»»»»»\n" +
                                    "»»»»»»»»\n" +
                                    "»»»»»»»»";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
    }
}
