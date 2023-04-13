using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift.UI;
using Gift.UI.Display;
using Gift.UI.Displayer;
using Gift.UI.MetaData;

namespace Gift
{
    public class GiftBase
    {
        public GiftUI? ui { get; set; }
        private IRenderer _renderer;
        private IDisplayer _displayer;


        public const char FILLINGCHAR = '*';


        public GiftBase(IRenderer? renderer = null, IDisplayer? displayer = null)
        {
            _renderer = renderer?? new Renderer();
            _displayer = displayer?? new ConsoleDisplayer();
        }

        public virtual void initialize()
        {
            ui = new GiftUI();
        }
        public virtual void initialize(GiftUI ui)
        {
            this.ui = ui;
        }
        public virtual void run()
        {
            while (true)
            {
                IScreenDisplay view = CreateView();
                PrintFrame(view);
                Thread.Sleep(1000);
            }
        }
        public IScreenDisplay CreateView()
        {
            IScreenDisplay View = new ScreenDisplay(new Bound(0,0));
            if (ui != null)
            {
                View = _renderer.GetRenderDisplay(ui);
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

        public virtual void end()
        {

        }

    }
}
