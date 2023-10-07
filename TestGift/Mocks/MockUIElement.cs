using Gift.UI.Conf;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace TestGift.Mocks
{
    public class MockUIElement : UIElement
    {
        public override int Height { get; }
        public override int Width { get; }

        private bool _isFixed;

        public MockUIElement(int height, int width, bool isFixed = false)
        {
            Height = height;
            Width = width;
			_isFixed = isFixed;
        }

        public MockUIElement()
        {
        }

        public override IScreenDisplay GetDisplayBorder(Bound bound, IConfiguration configuration)
        {
            throw new System.NotImplementedException();
        }

        public override IScreenDisplay GetDisplayWithoutBorder(Bound bounds, IConfiguration configuration)
        {
            throw new System.NotImplementedException();
        }

        public override Position GetRelativePosition(Context context)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsFixed()
        {
			return _isFixed;
        }
    }
}
