using Gift.Domain.UIModel.Display;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel.Display
{
    public class ScreenDisplayBuilder
    {
        private char _char = '*';
        private Color _backColor = Color.Default;
        private Color _frontColor = Color.Default;
        private Size _bound = new Size(0, 0);

        public ScreenDisplayBuilder WithBound(Size bound)
        {
            _bound = bound;
            return this;
        }

        public ScreenDisplayBuilder WithFrontColor(Color color)
        {
            _frontColor = color;
            return this;
        }

        public ScreenDisplayBuilder WithBackColor(Color color)
        {
            _backColor = color;
            return this;
        }

        public ScreenDisplayBuilder WithChar(char filling)
        {
            _char = filling;
            return this;
        }

        public ScreenDisplay Build()
        {
            return new ScreenDisplay(_bound, _frontColor, _backColor, _char);
        }
    }
}
