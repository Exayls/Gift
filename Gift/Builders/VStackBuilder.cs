using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI;
using Gift.UI.Border;
using Gift.UI.Factory;

namespace Gift.Builders
{
    public class VStackBuilder
    {
        private IBorder Border = new NoBorder();
        private IScreenDisplayFactory screenDisplayFactory = new ScreenDisplayFactory();

        public VStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public VStack Build()
        {
            return new VStack( Border, screenDisplayFactory);
        }
    }
} 