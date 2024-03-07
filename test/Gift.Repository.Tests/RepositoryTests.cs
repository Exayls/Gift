using Gift.Domain.Builders;
using Gift.Domain.UIModel.Element;
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

        [Fact]
        public void
        Given_root_have_1_container_as_its_root_and_no_other_when_GetSelectableContainer_should_retrieve_them()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().IsSelectableContainer(true).Build();
            repository.SaveRoot(root);
            var containers = repository.GetContainers();

            Assert.Collection<Container>(containers, container =>
                                                     { Assert.Equal(root, container); });
        }

        [Fact]
        public void
        Given_root_have_0_container_as_its_root_and_no_other_when_GetContainer_should_return_empty_collection()
        {
            IRepository repository = new InMemoryRepository();
            var containers = repository.GetContainers();

            Assert.Empty(containers);
        }

        [Fact]
        public void Given_root_have_1_container_as_its_root_and_no_other_when_GetContainer_should_retrieve_it()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().Build();
            repository.SaveRoot(root);
            var containers = repository.GetContainers();

            Assert.Collection<Container>(containers, container =>
                                                     { Assert.Equal(root, container); });
        }

        [Fact]
        public void Given_root_have_containers_in_hierarchy_when_GetContainer_should_retrieve_them1()
        {
            IRepository repository = new InMemoryRepository();
            HStack hstack = new HStackBuilder().Build();
            var root = new VStackBuilder()
                           .WithUnSelectableElement(
                               hstack)
                           .Build();

            repository.SaveRoot(root);
            var containers = repository.GetContainers();

            Assert.Collection<Container>(containers,
                                         container =>
                                         { Assert.Equal(root, container); },
                                         container =>
                                         { Assert.Equal(hstack, container); });
        }

        [Fact]
        public void Given_root_have_containers_in_hierarchy_when_GetContainer_should_retrieve_them()
        {
            IRepository repository = new InMemoryRepository();
            VStack vstack = new VStackBuilder().Build();
            HStack hstack = new HStackBuilder().WithUnSelectableElement(vstack).Build();
            var root = new VStackBuilder()
                           .WithUnSelectableElement(
                               hstack)
                           .Build();

            repository.SaveRoot(root);
            var containers = repository.GetContainers();

            Assert.Collection<Container>(containers,
                                         container =>
                                         { Assert.Equal(root, container); },
                                         container =>
                                         { Assert.Equal(hstack, container); },
                                         container =>
                                         { Assert.Equal(vstack, container); });
        }
    }
}
