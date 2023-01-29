using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGift.LifeCycle
{
    public class NewTickTest
    {
        [Fact]
        public void TestTickExist()
        {
            var GiftBase = new GiftBase();
            GiftBase.Tick();
        }
        [Fact]
        public void TestTickReturnNewRender()
        {
            var GiftBase = new GiftBase();
            GiftBase.GetCurrentView();
            GiftBase.Tick();

        }
    }
}
