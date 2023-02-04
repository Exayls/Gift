using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TestGift.LifeCycle
{
    public class NewTickTest
    {
        private Mock<Renderer> _rendererMock;

        public NewTickTest()
        {
            _rendererMock = new Mock<Renderer>();
        }
        [Fact]
        public void TestTickExist()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);
            GiftBase.Tick();
        }
        [Fact]
        public void TestTickReturnNewRender()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);
            GiftBase.GetCurrentView();
            GiftBase.Tick();

        }
    }
}
