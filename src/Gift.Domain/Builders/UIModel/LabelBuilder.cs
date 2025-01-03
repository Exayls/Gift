using System;
using Gift.Domain.Builders.Mappers;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.UIModel
{
    public class LabelBuilder : UIElementBuilder
    {
        private string text = "Hello";
        private Position? position;
        private Color backColor = Color.Default;
        private Color frontColor = Color.Default;
        private IBorder? border = new NoBorder();
        private string _id = Guid.NewGuid().ToString();

        public LabelBuilder()
        {

        }
        public LabelBuilder WithText(string text)
        {
            this.text = text;
            return this;
        }

        public override LabelBuilder WithBackgroundColor(Color color)
        {
            backColor = color;
            return this;
        }
        public override LabelBuilder WithForegroundColor(Color color)
        {
            frontColor = color;
            return this;
        }

        public override LabelBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public LabelBuilder WithPosition(Position position)
        {
            this.position = position;
            return this;
        }

        public override LabelBuilder WithBorder(IBorder border)
        {
            this.border = border;
            return this;
        }

        public override Label Build()
        {
            return new Label(text, position: position, frontColor: frontColor, backColor: backColor, border: border, id: _id);
        }

        public override LabelBuilder WithBorder(string borderStr, IBorderMapper mapper)
        {
            return WithBorder(mapper.ToBorder(borderStr));
        }

        public override LabelBuilder WithBackgroundColor(string colorStr, IColorMapper mapper)
        {
            return WithBackgroundColor(mapper.ToColor(colorStr));
        }

        public override LabelBuilder WithForegroundColor(string colorStr, IColorMapper mapper)
        {
            return WithForegroundColor(mapper.ToColor(colorStr));
        }

    }

}
