using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.ServiceContracts;

namespace Gift.Domain.Services
{
    public class TrueElementSizeCalculator : IElementSizeCalculator
    {
        public Size GetTrueSize(Container element)
        {
			return new Size(element.Height, element.Width);

        }
        public Size GetTrueSize(UIElement element)
        {
			return new Size(element.Height, element.Width);

        }
    }
}
