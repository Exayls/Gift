using Gift.Domain.UIModel.Border;

namespace Gift.Domain.Builders.Mappers
{
    public interface IBorderMapper
    {
		IBorder ToBorder(string borderStr);
    }
}
