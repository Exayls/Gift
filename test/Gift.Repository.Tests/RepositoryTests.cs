using Gift.Domain.Builders;
using Xunit;

namespace Gift.Repository.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void When_saving_root_should_be_able_to_retrieve_it()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().Build();
            repository.SaveRoot(root);
            var result = repository.GetRoot();
            Assert.Equal(root, result);
        }

    }
}
