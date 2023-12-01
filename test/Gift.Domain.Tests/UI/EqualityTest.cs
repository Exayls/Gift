
using Gift.Domain.Builders;
using TestGift.Mocks;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    public class EqualityTest
    {


        public EqualityTest()
        {
        }


        [Fact]
        public void GiftUI_are_equals_when_2_are_default()
        {
            //Arrange
			var giftUIRef = new GiftUIBuilder()
				.Build();
			var giftUI = new GiftUIBuilder()
				.Build();
			//Assert
            Assert.Equal(giftUIRef, giftUI);
        }
    }
}
