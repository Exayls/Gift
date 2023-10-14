using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.UnitTest.Border
{
    public class BorderTest
    {
        private BorderOption borderchars;
        private DetailedBorder _border;

        public BorderTest()
        {
            borderchars = BorderOption.GetBorderCharsFromFile("ressources/borderchars/double_border.json");
            _border = new DetailedBorder(1, borderchars);
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_1()
        {
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(2, 2));
            //assert
            const string expected = "╔╗\n" +
                                    "╚╝";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_2()
        {
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(4, 4), ' ');
            //assert
            const string expected = "╔══╗\n" +
                                    "║  ║\n" +
                                    "║  ║\n" +
                                    "╚══╝";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_1_when_border_thickness_equal_1_3()
        {
            //arrange
            _border = new DetailedBorder(1, '┌', '┐', '└', '┘', '─', '─', '│', '│');
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(4, 4), '*');
            //assert
            const string expected = "┌──┐\n" +
                                    "│**│\n" +
                                    "│**│\n" +
                                    "└──┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_1()
        {
            //arrange
            _border = new DetailedBorder(2, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(6, 6), ' ');
            //assert
            const string expected = "┌────┐\n" +
                                    "│┌──┐│\n" +
                                    "││  ││\n" +
                                    "││  ││\n" +
                                    "│└──┘│\n" +
                                    "└────┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_2()
        {
            //arrange
            _border = new DetailedBorder(2, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 8), ' ');
            //assert
            const string expected = "┌──────┐\n" +
                                    "│┌────┐│\n" +
                                    "││    ││\n" +
                                    "││    ││\n" +
                                    "││    ││\n" +
                                    "││    ││\n" +
                                    "│└────┘│\n" +
                                    "└──────┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_3()
        {
            //arrange
            _border = new DetailedBorder(3, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 8), ' ');
            //assert
            const string expected = "┌──────┐\n" +
                                    "│┌────┐│\n" +
                                    "││┌──┐││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "││└──┘││\n" +
                                    "│└────┘│\n" +
                                    "└──────┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_when_border_not_square_1()
        {
            //arrange
            _border = new DetailedBorder(3, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(12, 8), ' ');
            //assert
            const string expected = "┌──────┐\n" +
                                    "│┌────┐│\n" +
                                    "││┌──┐││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "│││  │││\n" +
                                    "││└──┘││\n" +
                                    "│└────┘│\n" +
                                    "└──────┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_when_border_not_square_2()
        {
            //arrange
            _border = new DetailedBorder(3, BorderOption.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 12), ' ');
            //assert
            const string expected = "┌──────────┐\n" +
                                    "│┌────────┐│\n" +
                                    "││┌──────┐││\n" +
                                    "│││      │││\n" +
                                    "│││      │││\n" +
                                    "││└──────┘││\n" +
                                    "│└────────┘│\n" +
                                    "└──────────┘";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
    }
}
