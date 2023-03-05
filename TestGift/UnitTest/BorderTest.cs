using System;
using Gift.UI.Border;
using Gift.UI.Interface;
using Gift.UI.MetaData;

namespace TestGift.UnitTest
{
    public class BorderTest
    {
        private BorderChars borderchars;
        private Border _border;

        public BorderTest()
        {
            borderchars = BorderChars.GetBorderCharsFromFile("ressources/borderchars/double_border.json");
            _border = new Border(1, borderchars);
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
            _border = new Border(1, '┏', '┓', '┗', '┛', '━', '━', '┃', '┃');
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(4, 4), '*');
            //assert
            const string expected = "┏━━┓\n" +
                                    "┃**┃\n" +
                                    "┃**┃\n" +
                                    "┗━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_1()
        {
            //arrange
            _border = new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(6, 6), ' ');
            //assert
            const string expected = "┏━━━━┓\n" +
                                    "┃┏━━┓┃\n" +
                                    "┃┃  ┃┃\n" +
                                    "┃┃  ┃┃\n" +
                                    "┃┗━━┛┃\n" +
                                    "┗━━━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_2()
        {
            //arrange
            _border = new Border(2, BorderChars.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 8), ' ');
            //assert
            const string expected = "┏━━━━━━┓\n" +
                                    "┃┏━━━━┓┃\n" +
                                    "┃┃    ┃┃\n" +
                                    "┃┃    ┃┃\n" +
                                    "┃┃    ┃┃\n" +
                                    "┃┃    ┃┃\n" +
                                    "┃┗━━━━┛┃\n" +
                                    "┗━━━━━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_with_thickness_n_when_border_thickness_greater_than_1_3()
        {
            //arrange
            _border = new Border(3, BorderChars.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 8), ' ');
            //assert
            const string expected = "┏━━━━━━┓\n" +
                                    "┃┏━━━━┓┃\n" +
                                    "┃┃┏━━┓┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┗━━┛┃┃\n" +
                                    "┃┗━━━━┛┃\n" +
                                    "┗━━━━━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_when_border_not_square_1()
        {
            //arrange
            _border = new Border(3, BorderChars.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(12, 8), ' ');
            //assert
            const string expected = "┏━━━━━━┓\n" +
                                    "┃┏━━━━┓┃\n" +
                                    "┃┃┏━━┓┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┃  ┃┃┃\n" +
                                    "┃┃┗━━┛┃┃\n" +
                                    "┃┗━━━━┛┃\n" +
                                    "┗━━━━━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
        [Fact]
        public void GetDisplay_should_return_border_when_border_not_square_2()
        {
            //arrange
            _border = new Border(3, BorderChars.GetBorderCharsFromFile("ressources/borderchars/simple_border.json"));
            //act
            IScreenDisplay display = _border.GetDisplay(new Bound(8, 12), ' ');
            //assert
            const string expected = "┏━━━━━━━━━━┓\n" +
                                    "┃┏━━━━━━━━┓┃\n" +
                                    "┃┃┏━━━━━━┓┃┃\n" +
                                    "┃┃┃      ┃┃┃\n" +
                                    "┃┃┃      ┃┃┃\n" +
                                    "┃┃┗━━━━━━┛┃┃\n" +
                                    "┃┗━━━━━━━━┛┃\n" +
                                    "┗━━━━━━━━━━┛";
            Assert.Equal(expected, display.DisplayString.ToString());
        }
    }
}
