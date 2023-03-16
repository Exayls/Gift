using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.MetaData
{
    public class Context
    {
        public Context(Position globalPosition, Bound localBounds)
        {
            Position = globalPosition;
            Bounds = localBounds;
        }

        public Position Position { get; private set; }
        public Bound Bounds { get; private set; }

    }
}
