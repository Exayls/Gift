using System;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public class BoundMapper : IBoundMapper
    {
        public Size ToBound(string boundStr)
        {
            try
            {
                var splitBound = boundStr.Split(new[] { ',', ';' });
                var bound = new Size(int.Parse(splitBound[0]), int.Parse(splitBound[1]));
                return bound;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"{boundStr} is not a valid parameter for ToBound, it must be (height,width)", e);
            }
        }
    }
}
