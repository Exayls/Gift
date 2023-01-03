using Gift.UI;
using Gift.UI.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift.Builders
{
    /// <summary>
    /// build Label with "Hello" as default text and (0,0) as default position
    /// </summary>
    public class LabelBuilder
    {
        private string text = "Hello";
        private Position position = new Position(0,0);

        public LabelBuilder()
        {

        }
        public LabelBuilder WithText(string text)
        {
            this.text = text;
            return this;
        }
        public LabelBuilder WithPosition(Position position)
        {
            this.position = position;
            return this;
        }
        public Label build()
        {
            return new Label(text, position);
        }
    }
}
