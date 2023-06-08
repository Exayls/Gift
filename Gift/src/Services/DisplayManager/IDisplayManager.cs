using Gift.src.UIModel;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.DisplayManager
{
    public interface IDisplayManager
    {
        void NextContainer();
        void NextElementInSelectedContainer();
        void PreviousContainer();
        void PreviousElementInSelectedContainer();
        void Resize(Bound bound);
        void ScrollDown();
        void ScrollUp();
        void UpdateDisplay();
    }
}
