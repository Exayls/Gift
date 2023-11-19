using Gift.Domain.UIModel.Border;

namespace Gift.Domain.Builders
{
    public interface IBorderMapper
    {
		IBorder ToBorder(string borderStr);
    }
}
