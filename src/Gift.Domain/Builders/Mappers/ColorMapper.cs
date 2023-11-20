using System;
using Gift.Domain.Builders;
using Gift.Domain.UIModel.MetaData;

namespace TestGift.Builder
{
    public class ColorMapper : IColorMapper
    {
        public Color ToColor(string colorAtt)
        {
			Color color;
			var success = Enum.TryParse<Color>(colorAtt, true, out color);
			if (!success)
			{
				throw new ArgumentException($"Attribute {colorAtt} can't be converted to color");
			}
			return color;
        }
    }
}
