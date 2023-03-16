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
        private Position position = new Position(0,0);

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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>instance of Label</returns>
        public Label Build()
        {
            return new Label(text, position);
        }
        public Label BuildImplicit()
        {
            return new Label(text);
        }

    }
}
