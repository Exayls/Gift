using Gift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gift.UI.Render;

namespace TestGift.LifeCycle
{
    public class GiftBaseTest
    {
        private Mock<IRenderer> _rendererMock;

        public GiftBaseTest()
        {
            _rendererMock = new Mock<IRenderer>();
        }
        [Fact]
        public void When_not_initialized_should_not_set_ui()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);

            Assert.True(GiftBase.Ui == null);

        }
        [Fact]
        public void When_initialized_should_set_ui()
        {
            var GiftBase = new GiftBase(_rendererMock.Object);
            GiftBase.Initialize();

            Assert.True(GiftBase.Ui != null);

        }
    }
}
