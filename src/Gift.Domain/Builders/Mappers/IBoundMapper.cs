using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public interface IBoundMapper
    {
		Bound ToBound(string boundStr);
    }
}
