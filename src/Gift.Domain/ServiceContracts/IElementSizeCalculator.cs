using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.ServiceContracts{
    public interface IElementSizeCalculator
    {
		public Size GetTrueSize(Container element);
		public Size GetTrueSize(UIElement element);
    }
}
