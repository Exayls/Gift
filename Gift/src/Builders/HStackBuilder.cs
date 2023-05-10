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
    public class HStackBuilder
    {
        private IBorder Border = new NoBorder();
        private Bound Bound = new Bound(0, 0);
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();

        public HStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public HStackBuilder WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }
        public HStack Build()
        {
            return new HStack(Border, screenDisplayFactory, Bound);
        }
    }
}