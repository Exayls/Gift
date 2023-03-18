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
        public TextWriter? View { get; private set; }
        private IRenderer _renderer;

        public const char FILLINGCHAR = '*';


        public GiftBase(IRenderer renderer)
        {
            _renderer = renderer;
        }
        public GiftBase(IRenderer renderer, GiftUI ui)
        {
            _renderer = renderer;
            this.ui = ui;
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
                Tick();
                PrintFrame();
                Thread.Sleep(1000);
            }
        }
        public void Tick()
        {
            if (ui != null)
            {
                View = _renderer.GetRenderWriter(ui);
            }

        }
        private void PrintFrame()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();
            if (View != null)
            {
                Console.Out.Write(View);
            }
        }

        public virtual void end()
        {

        }

    }
}
