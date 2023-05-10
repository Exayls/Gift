using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.MetaData;
using Gift.UI.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.UI.DisplayManager
{
    public class DisplayManager : IDisplayManager
    {
        private IDisplayer _displayer;
        public IGiftUI Ui { get; private set; }
        private IRenderer _renderer;

        public DisplayManager(IDisplayer displayer, IRenderer renderer, IGiftUI ui)
        {
            _displayer = displayer;
            Ui = ui;
            _renderer = renderer;
        }
        public void UpdateDisplay()
        {
            IScreenDisplay view = CreateView();
            PrintFrame(view);
        }

        public IScreenDisplay CreateView()
        {
            IScreenDisplay View = new ScreenDisplay(new Bound(0, 0));
            if (Ui != null)
            {
                View = _renderer.GetRenderDisplay(Ui);
            }
            return View;
        }
        private void PrintFrame(IScreenDisplay? View)
        {
            if (View != null)
            {
                _displayer.display(View);
            }
        }
    }
}
