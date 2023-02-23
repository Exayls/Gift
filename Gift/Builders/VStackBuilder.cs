using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI;
using Gift.UI.Interface;

namespace Gift.Builders
{
    public class VStackBuilder
    {
        private IBorder Border = new NoBorder();

        public VStackBuilder WithBorder(IBorder border)
        {
            Border = border;
            return this;
        }
        public VStack Build()
        {
            return new VStack( Border);
        }
    }
}
