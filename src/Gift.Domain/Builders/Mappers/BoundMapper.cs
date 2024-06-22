using System;
using System.Globalization;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public class BoundMapper : IBoundMapper
    {
        public Size ToBound(string boundStr)
        {
            try
            {
                var splitBound = boundStr.Split([',', ';']);
                var bound = new Size(int.Parse(splitBound[0], NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat), int.Parse(splitBound[1], NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat));
                return bound;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"{boundStr} is not a valid parameter for ToBound, it must be (height,width)", e);
            }
        }
    }
}
