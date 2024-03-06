using Gift.Domain.Builders;
using Xunit;

namespace Gift.Repository.Tests
{
    public class RepositoryTests
    {
        [Fact]
        public void Test1()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().Build();
            repository.SaveRoot(root);
            var result = repository.GetRoot();
			
        }
    }
}
