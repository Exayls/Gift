using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders.Mappers
{
    public interface IColorMapper
    {
        Color ToColor(string colorAtt);
    }
}
