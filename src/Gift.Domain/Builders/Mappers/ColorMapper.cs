using System;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public class ColorMapper : IColorMapper
    {
        public Color ToColor(string colorAtt)
        {
            var success = Enum.TryParse(colorAtt, true, out Color color);
            if (!success)
            {
                throw new ArgumentException($"Attribute {colorAtt} can't be converted to color");
            }
            return color;
        }
    }
}
