using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    public interface IColorMapper
    {
        Color ToColor(string colorAtt);
    }
}
