using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI;

namespace Gift
{
    public class GiftBase
    {
        public GiftUI? ui { get; set; }
        public const char FILLINGCHAR = '*';

        public virtual void initialize()
        {
            ui = null;
            
        }
        public virtual void run()
        {

        }
        public virtual void end()
        {

        }
    }
}
