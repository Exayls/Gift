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
        private Renderer _renderer;

        public const char FILLINGCHAR = '*';


        public virtual void initialize()
        {
            ui = new GiftUI();
            _renderer = new Renderer();
        }
        public virtual void run()
        {
            while (true)
            {
                Tick();
                if (View != null)
                {
                    Console.Out.Write(View);
                }
                Thread.Sleep(1000);
                Console.Clear();
                Console.Clear();
            }
        }
        public virtual void end()
        {

        }

        public void Tick()
        {
            if (ui != null)
            {
                View = _renderer.GetRenderedBuffer(ui);
            }

        }

        public TextWriter GetCurrentView()
        {
            return View;
        }
    }
}
