
using System.Globalization;

namespace Gift.Domain.Builders.Mappers
{
    public class BoolMapper : IBooleanMapper
    {
        public bool ToBool(string str)
        {
            return str.ToLower(CultureInfo.CurrentCulture).Equals("true", System.StringComparison.Ordinal);
        }
    }
}
