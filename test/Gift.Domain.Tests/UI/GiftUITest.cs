using Gift.Domain.Builders;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Moq;
using System;
using Xunit;

namespace Gift.Domain.Tests.UI
{
    //public class GiftUITest
    //{
    //    private Mock<IScreenDisplay> _screenDisplayMock1;
    //    private Mock<IBorder> _borderMock;
    //    private Mock<IScreenDisplayFactory> _ScreenDisplayFactoryMock;
    //    private GiftUI giftui;

    //    public GiftUITest()
    //    {
    //        _screenDisplayMock1 = new Mock<IScreenDisplay>();
    //        _borderMock = new Mock<IBorder>();
    //        _ScreenDisplayFactoryMock = new Mock<IScreenDisplayFactory>();
    //        _ScreenDisplayFactoryMock.Setup(s => s.Create(It.IsAny<Bound>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<char>())).Returns(_screenDisplayMock1.Object);
    //        giftui = new GiftUIBuilder().WithBound(new Bound(5, 5)).WithBorder(_borderMock.Object).Build();
    //    }

    //    [Fact]
    //    public void Height_and_Width_should_return_Bounds()
    //    {
    //        //assert
    //        Assert.Equal(5, giftui.Height);
    //        Assert.Equal(5, giftui.Width);
    //    }

    //    [Fact]
    //    public void SelectedContainer_should_throw_when_nulll_value()
    //    {
    //        Assert.Throws<ArgumentNullException>(() => giftui.SelectedContainer = null);
    //    }

    //    [Fact]
    //    public void SelectedContainer_should_throw_when_setting_container_outside_of_selectable()
    //    {

    //        var container = new VStackBuilder().Build();
    //        Assert.Throws<InvalidOperationException>(() => giftui.SelectedContainer = container);
    //    }

    //    [Fact]
    //    public void SelectedContainer_should_define_selected_container_as_selected()
    //    {
    //        var container = new GiftUIBuilder().Build();
    //        var uiElement = new Mock<UIElement>();
    //        //Act
    //        //
    //        giftui.SelectableContainers.Add(container);
    //        giftui.SelectedContainer = container;
    //        Assert.Equal(container, giftui.SelectedContainer);
    //        Assert.True(container.IsSelectedContainer);
    //    }

    //    [Fact]
    //    public void IsFixed_should_return_false()
    //    {
    //        Assert.False(giftui.IsFixed());
    //    }

    //    [Fact]
    //    public void NextContainer_should_do_nothing_if_selectedContainer_null()
    //    {
    //        //Act
    //        giftui.NextContainer();
    //        //Assert
    //        Assert.Null(giftui.SelectedContainer);
    //    }

    //    [Fact]
    //    public void NextContainer_should_not_change_container_if_selectedContainer_is_only_selectable()
    //    {
    //        //Arrange
    //        Container container = new GiftUIBuilder().Build();
    //        giftui.SelectableContainers.Add(container);
    //        giftui.SelectedContainer = container;
    //        //Act
    //        giftui.NextContainer();
    //        //Assert
    //        Assert.Equal(container, giftui.SelectedContainer);
    //        Assert.True(container.IsSelectedContainer);
    //    }

    //    [Fact]
    //    public void NextContainer_should_change_container_if_selectedContainer_is_not_only_selectable()
    //    {
    //        //Arrange
    //        var container1 = new VStackBuilder().Build();

    //        var container2 = new VStackBuilder().Build();

    //        giftui.SelectableContainers.Add(container1);
    //        giftui.SelectableContainers.Add(container2);

    //        giftui.SelectedContainer = container1;
    //        //Act
    //        giftui.NextContainer();
    //        //Assert
    //        Assert.Equal(container2, giftui.SelectedContainer);
    //    }

    //    [Fact]
    //    public void PreviousContainer_should_change_container_if_selectedContainer_is_not_only_selectable()
    //    {
    //        //Arrange
    //        var container1 = new VStackBuilder().Build();

    //        var container2 = new VStackBuilder().Build();

    //        giftui.SelectableContainers.Add(container1);
    //        giftui.SelectableContainers.Add(container2);

    //        giftui.SelectedContainer = container1;
    //        //Act
    //        giftui.PreviousContainer();
    //        //Assert
    //        Assert.Equal(container2, giftui.SelectedContainer);
    //    }

    //    [Fact]
    //    public void NextElementInSelectedContainer_should_not_change_element_in_selected_container_if_selectedContainer_is_null()
    //    {
    //        //Act
    //        giftui.NextElementInSelectedContainer();
    //        Assert.True(true);

    //    }

    //    [Fact]
    //    public void NextElementInSelectedContainer_should_call_nextElement_if_selectedContainer_is_not_null()
    //    {
    //        //Arrange
    //        var giftui = GetGiftUI();
    //        var container = GetContainer();
    //        giftui.SelectableContainers.Add(container);

    //        var e1 = new GiftUIBuilder().Build();
    //        var e2 = new GiftUIBuilder().Build();
    //        container.AddSelectableChild(e1);
    //        container.AddSelectableChild(e2);
    //        giftui.SelectableContainers.Add(container);
    //        giftui.SelectedContainer = container;
    //        //Act
    //        giftui.NextElementInSelectedContainer();
    //        //Assert
    //        Assert.Equal(e2, container.SelectedElement);
    //    }

    //    private Container GetContainer()
    //    {
    //        return new GiftUIBuilder().Build();
    //    }

    //    private GiftUI GetGiftUI()
    //    {
    //        return new GiftUIBuilder().Build();
    //    }

    //    [Fact]
    //    public void PreviousElementInSelectedContainer_should_call_previous_Element_if_selectedContainer_is_not_null()
    //    {
    //        //Arrange
    //        var giftui = new GiftUIBuilder().Build();
    //        var container = new GiftUIBuilder().Build();
    //        var e1 = new GiftUIBuilder().Build();
    //        var e2 = new GiftUIBuilder().Build();
    //        container.AddSelectableChild(e1);
    //        container.AddSelectableChild(e2);
    //        giftui.SelectableContainers.Add(container);
    //        giftui.SelectedContainer = container;
    //        //Act
    //        giftui.PreviousElementInSelectedContainer();
    //        //Assert
    //        Assert.Equal(e2, container.SelectedElement);
    //    }
    // }
}
