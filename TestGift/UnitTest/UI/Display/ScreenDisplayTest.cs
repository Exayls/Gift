using Gift.UI.Display;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UI.Display
{
    public class ScreenDisplayTest
    {
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "******@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, 3));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@******@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_add_screen3()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), ' '); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), 'p');
            //act
            screen.AddDisplay(screenToAdd, new Position(1, 0));
            //assert
            string expectedDisplay =
                "          \n" +
                "pppppp    \n" +
                "          ";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, -2));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "****@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, -4));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "**@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen3()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, 5));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@@@*****";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen4()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, 7));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@***";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen5()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(5, 5));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_partof_2nd_screen_over_when_add_screen_offscreen6()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(2, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(-1, 5));
            //assert
            string expectedDisplay =
                "@@@@@*****\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_1st_screen_when_add_screen_completely_offscreen1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, 13));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_1st_screen_when_add_screen_completely_offscreen2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 6), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(4, 5));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Bigger()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(4, 14), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(1, 7));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@***\n" +
                "@@@@@@@***";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 10), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(0, 0));
            //assert
            string expectedDisplay =
                "**********\n" +
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(3, 10), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(0, 0));
            //assert
            string expectedDisplay =
                "**********\n" +
                "**********\n" +
                "**********";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddDisplay_should_display_2nd_screen_over_when_2nd_screen_Same_size3()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(3, 10), '@'); ;
            ScreenDisplay screenToAdd = new ScreenDisplay(new Bound(1, 10), '*');
            //act
            screen.AddDisplay(screenToAdd, new Position(2, 0));
            //assert
            string expectedDisplay =
                "@@@@@@@@@@\n" +
                "@@@@@@@@@@\n" +
                "**********";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(2, 0));
            //assert
            string expectedDisplay =
                "@@@\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(3, 0));
            //assert
            string expectedDisplay =
                "@@@\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_not_in_Display3()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(-1, 0));
            //assert
            string expectedDisplay =
                "@@@\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display1()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(0, 0));
            //assert
            string expectedDisplay =
                "aa@\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display2()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(0, 1));
            //assert
            string expectedDisplay =
                "@aa\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display3()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(0, 2));
            //assert
            string expectedDisplay =
                "@@a\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
        [Fact]
        public void AddString_should_add_display_string_when_position_in_Display4()
        {
            //arrange
            ScreenDisplay screen = new ScreenDisplay(new Bound(2, 3), '@'); ;
            //act
            screen.AddString("aa", new Position(0, -1));
            //assert
            string expectedDisplay =
                "a@@\n" +
                "@@@";
            string actual = screen.DisplayString.ToString();
            Assert.Equal(expectedDisplay, actual);
        }
    }
}
