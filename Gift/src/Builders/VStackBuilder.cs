using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI.Border;
using Gift.UI.Display;
using Gift.UI.Element;
using Gift.UI.MetaData;

namespace Gift.Builders
{
    public class VStackBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;

        public VStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public VStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        public VStackBuilder WithBackgroundColor(Color color)
        {
            this.backColor = color;
            return this;
        }

        public VStackBuilder WithForegroundColor(Color color)
        {
            this.frontColor = color;
            return this;
        }

        public VStack Build()
        {
            return new VStack(Border,
                              screenDisplayFactory,
                              Bound,
                              frontColor: frontColor,
                              backColor: backColor);
        }

    }
}