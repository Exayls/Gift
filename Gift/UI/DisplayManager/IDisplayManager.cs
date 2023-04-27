using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.DisplayManager
{
    public interface IDisplayManager
    {
        IGiftUI Ui { get; }

        void UpdateDisplay();
    }
}
