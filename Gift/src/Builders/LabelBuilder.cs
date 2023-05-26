using Gift.UI.Border;
using Gift.UI.Element;
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
        private Position? position = null;
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private IBorder? border = new NoBorder();

        /// <summary>
        /// Get Label instance with "Hello" as default text and (0,0) as default position
        /// </summary>
        public LabelBuilder()
        {

        }
        /// <summary>
        /// Set text parameter to the builder
        /// </summary>
        /// <param name="text"></param>
        /// <returns>LabelBuilder instance</returns>
        public LabelBuilder WithText(string text)
        {
            this.text = text;
            return this;
        }

        public LabelBuilder WithBackgroundColor(Color color)
        {
            this.backColor = color;
            return this;
        }
        public LabelBuilder WithForegroundColor(Color color)
        {
            this.frontColor = color;
            return this;
        }

        /// <summary>
        /// Set position parameter to the builder
        /// </summary>
        /// <param name="position"></param>
        /// <returns>LabelBuilder instance</returns>
        public LabelBuilder WithPosition(Position position)
        {
            this.position = position;
            return this;
        }

        internal LabelBuilder WithBorder(IBorder border)
        {
            this.border = border;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>instance of Label</returns>
        public Label Build()
        {
            return new Label(text, position: position,frontColor: this.frontColor, backColor: this.backColor, border:this.border);
        }

    }

}
