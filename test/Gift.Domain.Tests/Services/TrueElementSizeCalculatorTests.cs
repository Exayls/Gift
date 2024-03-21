using Gift.Domain.Builders.UIModel;
using Gift.Domain.Services;
using Gift.Domain.UIModel.MetaData;
using Xunit;

namespace Gift.Domain.Tests.Services
{
    public class TrueElementSizeCalculatorTests
    {
        [Fact]
        public void When_compute_size_of_label_hello_should_return_1_5()
        {
            var element = new LabelBuilder().WithText("hello").Build();
			var sizeCalculator = new TrueElementSizeCalculator();
            var size = sizeCalculator.GetTrueSize(element);
			Assert.True(size.Equals(new Size(1,5)));
        }

    }
}
