using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public interface IBoundMapper
    {
        Size ToBound(string boundStr);
    }
}
