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
            GiftBase.initialize();
            GiftBase.Tick();
            var view = GiftBase.GetCurrentView();
            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 60));
            for (int i = 1; i < 20; i++)
            {
                expectedBuilder.Append('\n');
                expectedBuilder.Append(new string(GiftBase.FILLINGCHAR, 60));
            }

            Assert.Equal(expectedBuilder.ToString(), view.ToString());

        }
    }
}
