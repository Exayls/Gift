using Xunit;
using Gift.Domain.UIModel.Element;
using Gift.Domain.ServiceContracts;
using Gift.Domain.Builders.UIModel;

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
            var root = new VStackBuilder().WithUnSelectableElement(hstack).Build();

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
            var root = new VStackBuilder().WithUnSelectableElement(hstack).Build();

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

        [Fact]
        public void Given_root_have_selectable_containers_in_hierarchy_when_GetContainer_should_retrieve_them()
        {
            IRepository repository = new InMemoryRepository();
            VStack vstack = new VStackBuilder().IsSelectableContainer(true).Build();
            HStack hstack = new HStackBuilder().WithUnSelectableElement(vstack).Build();
            var root = new VStackBuilder().WithUnSelectableElement(hstack).IsSelectableContainer(true).Build();

            repository.SaveRoot(root);
            var containers = repository.GetSelectableContainers();

            Assert.Collection<Container>(containers,
                                         container =>
                                         { Assert.Equal(root, container); },
                                         container =>
                                         { Assert.Equal(vstack, container); });
        }

        [Fact]
        public void Given_root_have_no_selectable_containers_in_hierarchy_when_GetSelectedContainer_should_return_null()
        {
            IRepository repository = new InMemoryRepository();
            var container = repository.GetSelectedContainer();

            Assert.Equal(null, container);
        }

        [Fact]
        public void Given_root_have_selectable_containers_in_hierarchy_when_GetSelectedContainer_should_return_first()
        {
            IRepository repository = new InMemoryRepository();
            VStack vstack = new VStackBuilder().IsSelectableContainer(true).Build();
            HStack hstack = new HStackBuilder().WithUnSelectableElement(vstack).Build();
            var root = new VStackBuilder().WithUnSelectableElement(hstack).IsSelectableContainer(true).Build();

            repository.SaveRoot(root);
            var container = repository.GetSelectedContainer();

            Assert.Equal(root, container);
        }

        [Fact]
        public void
        Given_root_have_selectable_containers_in_hierarchy_when_GetSelectedContainer_should_return_selected()
        {
            IRepository repository = new InMemoryRepository();
            VStack vstack = new VStackBuilder().IsSelectableContainer(true).Build();
            HStack hstack = new HStackBuilder().WithUnSelectableElement(vstack).Build();
            var root = new VStackBuilder().WithUnSelectableElement(hstack).IsSelectableContainer(true).Build();

            repository.SaveRoot(root);
            repository.SelectContainer(vstack);
            var container = repository.GetSelectedContainer();

            Assert.Equal(vstack, container);
        }

        [Fact]
        public void Given_container_is_not_selectable_when_SelectContainer_should_throw()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().IsSelectableContainer(false).Build();
            repository.SaveRoot(root);

            Assert.Throws<UnSelectableContainerException>(() => repository.SelectContainer(root));
        }

        [Fact]
        public void Given_container_is_not_in_root_when_SelectContainer_should_throw()
        {
            IRepository repository = new InMemoryRepository();
            var root = new VStackBuilder().IsSelectableContainer(true).Build();
            repository.SaveRoot(root);
            var container = new VStackBuilder().IsSelectableContainer(true).Build();

            Assert.Throws<ElementNotInHierarchyException>(() => repository.SelectContainer(container));
        }
    }
}
