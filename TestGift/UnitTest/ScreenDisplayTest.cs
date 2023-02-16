﻿using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.UnitTest
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
    }
}
