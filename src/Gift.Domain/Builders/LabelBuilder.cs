using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    /// <summary>
    /// build Label with "Hello" as default text and (0,0) as default position
    /// </summary>
    public class LabelBuilder : IUIElementBuilder
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
            backColor = color;
            return this;
        }
        public LabelBuilder WithForegroundColor(Color color)
        {
            frontColor = color;
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
            return new Label(text, position: position, frontColor: frontColor, backColor: backColor, border: border);
        }

    }

}
