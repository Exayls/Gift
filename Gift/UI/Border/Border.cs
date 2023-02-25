using Gift.UI.Interface;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.Border
{
    public class Border : IBorder
    {
        public int Thickness { get; }


        public IScreenDisplay GetDisplay(Bound bound)
        {
            throw new NotImplementedException();
        }
    }
}
