
namespace Gift.Domain.Builders.Mappers
{
    public class BoolMapper : IBooleanMapper
    {
        public bool ToBool(string str)
        {
            return str.ToLower().Equals("true") ? true : false;
        }
    }
}
