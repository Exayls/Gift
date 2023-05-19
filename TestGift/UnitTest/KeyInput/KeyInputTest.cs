using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.KeyInput;
using Xunit;

namespace TestGift.UnitTest.KeyInput
{
    public class KeyInputTest
    {
        private KeyInputHandler keyinput;

        public KeyInputTest()
        {
        }

        [Fact]
        public void When_Pushing_signal_should_trigger_bus_subscribers()
        {
        }
    }
}
