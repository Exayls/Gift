using Gift.Domain.Builders.UIModel;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Services;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;
using Moq;
using Xunit;

namespace Gift.Domain.Tests.Services
{
    public class TrueElementSizeCalculatorTests
    {
        [Fact]
        public void When_compute_size_of_label_hello_should_return_1_5()
        {
			var repository = Mock.Of<IRepository>();
            var element = new LabelBuilder().WithText("hello").Build();
			var sizeCalculator = new TrueElementSizeCalculator(repository);
            var size = sizeCalculator.GetTrueSize(element);
			Assert.True(size.Equals(new Size(1,5)));
        }

        [Fact]
        public void When_compute_size_of_vstack_bound_0_0_that_take_4_7_size_should_return_4_7()
        {
			var repository = Mock.Of<IRepository>();
            var element = new VStackBuilder()
				.WithBound(new(0,0))
				.WithUnSelectableElement(new LabelBuilder().WithText("hello").Build())
				.WithUnSelectableElement(new LabelBuilder().WithText("he").Build())
				.WithBorder(new SimpleBorder(1, 'a'))
				.Build();
			var sizeCalculator = new TrueElementSizeCalculator(repository);
            var size = sizeCalculator.GetTrueSize(element);
			Assert.True(size.Equals(new Size(4,7)));
        }

        [Fact]
        public void When_compute_size_of_vstack_bound_2_3_should_return_2_3()
        {
			var repository = Mock.Of<IRepository>();
            var element = new VStackBuilder()
				.WithBound(new(2,3))
				.WithUnSelectableElement(new LabelBuilder().WithText("hello").Build())
				.WithUnSelectableElement(new LabelBuilder().WithText("he").Build())
				.WithBorder(new SimpleBorder(1, 'a'))
				.Build();
			var sizeCalculator = new TrueElementSizeCalculator(repository);
            var size = sizeCalculator.GetTrueSize(element);
			Assert.True(size.Equals(new Size(2,3)));
        }

        [Fact]
        public void When_compute_size_of_vstack_bound_negative_should_return_parent_size()
        {
			var repository = Mock.Of<IRepository>();
            var element = new VStackBuilder()
				.WithBound(new(-1,-1))
				.Build();
            var parent = new VStackBuilder()
				.WithBound(new(4,5))
				.WithUnSelectableElement(element)
				.WithBorder(new SimpleBorder(1, 'a'))
				.Build();

			Mock.Get<IRepository>(repository).Setup(r => r.GetParent(element)).Returns(parent);

			var sizeCalculator = new TrueElementSizeCalculator(repository);
            var size = sizeCalculator.GetTrueSize(element);
			Assert.True(size.Equals(new Size(2,3)));
		}
    }
}
