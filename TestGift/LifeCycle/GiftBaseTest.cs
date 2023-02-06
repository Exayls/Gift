using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TestGift.LifeCycle
{
    public class GiftBaseTest
    {
        private Mock<Renderer> _rendererMock;

        public GiftBaseTest()
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
        public void When_not_initialized_should_not_set_ui()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);

            Assert.True(GiftBase.ui == null);

        }
        [Fact]
        public void When_initialized_should_set_ui()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);
            GiftBase.initialize();

            Assert.True(GiftBase.ui != null);

        }
    }
}
