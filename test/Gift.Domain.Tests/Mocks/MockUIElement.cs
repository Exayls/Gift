using Gift.Domain.ServiceContracts;
using Gift.Domain.UIModel.Conf;
using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Tests.Mocks
{
    public class MockUIElement : UIElement
    {
        public override int Height { get; }
        public override int Width { get; }

        private readonly bool _isFixed;

        public MockUIElement(int height, int width, bool isFixed = false)
            : base(border: null, backColor: Color.Default, frontColor: Color.Default, id: "id")
        {
            Height = height;
            Width = width;
            _isFixed = isFixed;
        }

        public MockUIElement()
            : base(border: null, backColor: Color.Default, frontColor: Color.Default, id: "id")
        {
        }

        public override Position GetRelativePosition(Position position)
        {
            throw new System.NotImplementedException();
        }

        public override bool HasNoSize()
        {
            return _isFixed;
        }

        public override bool IsSimilarTo(UIElement uiElement)
        {
            return false;
        }

        public override IScreenDisplay GetDisplayWithoutBorder(IConfiguration configuration, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            throw new System.NotImplementedException();
        }

        public override IScreenDisplay GetDisplayBorder(IConfiguration configuratione, IColorResolver colorResolver, IElementSizeCalculator sizeCalculator)
        {
            throw new System.NotImplementedException();
        }
    }
}
