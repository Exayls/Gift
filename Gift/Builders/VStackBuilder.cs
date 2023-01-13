using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI;

namespace Gift.Builders
{
    /// <summary>
    /// Build default VStack 
    /// </summary>
    public class VStackBuilder
    {
    /// <summary>
    /// Get default VStack instance 
    /// </summary>
        public VStack Build()
        {
            return new VStack();
        }
    }
}
