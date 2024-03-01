using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.Display
{
    public class ScreenDisplayTest
    {
        private char[,] convert_string_to_char(string[] stringArray)
        {
            int numRows = stringArray.Length;
            int numCols = stringArray[0].Length;

            char[,] charArray = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    charArray[i, j] = stringArray[i][j];
                }
            }
            return charArray;
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] {
                // clang-format off
				 "@@@@@@@@@@",
                 "******@@@@",
                 "@@@@@@@@@@"
                // clang-format on
            });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }

        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, 3));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@******@" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen3()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: ' ');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: 'p');
            // act
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "          ", "pppppp    ", "          " });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, -2));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "****@@@@@@" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, -4));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "**@@@@@@@@" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen3()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, 5));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@@@*****" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen4()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, 7));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@@@@@***" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen5()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(5, 5));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@@@@@@@@" });

            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }

        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen6()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(2, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(-1, 5));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@*****", "@@@@@@@@@@", "@@@@@@@@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_1st_screen_when_add_screen_completely_offscreen1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, 13));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@@@@@@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_1st_screen_when_add_screen_completely_offscreen2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(4, 5));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "@@@@@@@@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Bigger()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(4, 14), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(1, 7));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@***", "@@@@@@@***" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 10), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(0, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "**********", "@@@@@@@@@@", "@@@@@@@@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(3, 10), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(0, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "**********", "**********", "**********" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size3()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 10), emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(2, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@@@@@@@@", "@@@@@@@@@@", "**********" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(2, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(3, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display3()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(-1, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display1()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(0, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "aa@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display2()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(0, 1));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@aa", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display3()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(0, 2));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@a", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display4()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), emptychar: '@');
            // act
            screen.AddString("aa", new Position(0, -1));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "a@@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }

        [Fact]
        public void AddDisplay_should_add_display_to_screen_when_add_nested_screen()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 3), emptychar: '@');
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 2), backColor: Color.Red, emptychar: '*');
            ScreenDisplay screenToAdd2 = new ScreenDisplay(new Bound(1, 1), backColor: Color.Green, emptychar: ' ');
            // act
            screenToAdd.AddDisplay(screenToAdd2, new Position(0, 0));
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            // assert
            char[,] expectedDisplay = convert_string_to_char(new string[] { "@@@", " *@", "@@@" });
            char[,] actual = screen.DisplayMap;
            Assert.Equal(expectedDisplay, actual);
        }

        // color test

        [Fact]
        public void AddDisplay_should_put_color_to_screen_when_add_screen()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 3), emptychar: '@', backColor: Color.Black);
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 2), backColor: Color.Red, emptychar: '*');
            // act
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            // assert
            Color[,] expectedColors = { { Color.Black, Color.Black, Color.Black },
                                        { Color.Red, Color.Red, Color.Black },
                                        { Color.Black, Color.Black, Color.Black } };

            Color[,] actual = screen.BackColorMap;
            Assert.Equal(expectedColors, actual);
        }

        [Fact]
        public void AddDisplay_should_put_color_to_screen_when_add_nested_screen()
        {
            // arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 3), emptychar: '@', backColor: Color.Black);
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 2), backColor: Color.Red, emptychar: '*');
            ScreenDisplay screenToAdd2 = new ScreenDisplay(new Bound(1, 1), backColor: Color.Green, emptychar: '*');
            // act
            screenToAdd.AddDisplay(screenToAdd2, new Position(0, 0));
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            // assert
            Color[,] expectedColors = { { Color.Black, Color.Black, Color.Black },
                                        { Color.Green, Color.Red, Color.Black },
                                        { Color.Black, Color.Black, Color.Black } };

            Color[,] actual = screen.BackColorMap;
            Assert.Equal(expectedColors, actual);
        }
    }
}
