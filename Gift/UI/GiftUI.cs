using Gift.UI.Interface;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI
{
    public class GiftUI : Container
    {

        public GiftUI(Bound bound) : base(bound)
        {
        }
        public GiftUI() 
        {
        }

        public void SetChild(UIElement UIElement)
        {
            foreach (UIElement r in Childs)
            {
                Childs.Remove(r);
            }
            Childs.Add(UIElement);

            UIElement.setContext(new Position(0, 0), Bound);
        }
    }
}
