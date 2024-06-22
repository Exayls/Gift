using Gift.Domain.Builders.UIModel.Display;
using Gift.Domain.UIModel.Display;

namespace Gift.Domain.UIModel.Border
{
    public class DetailedBorder : IBorder
    {
        private readonly BorderOption _borderChars;

        public int Thickness { get; }

        public DetailedBorder(int thickness, char tlBorder, char trBorder, char blBorder, char brBorder, char tBorder,
                              char bBorder, char lBorder, char rBorder)
        {
            _borderChars = new BorderOption(tlBorder, trBorder, blBorder, brBorder, tBorder, bBorder, lBorder, rBorder);
            Thickness = thickness;
        }
        public DetailedBorder(int thickness, BorderOption borderChars)
        {
            _borderChars = borderChars;
            Thickness = thickness;
        }


        public bool IsSimilarTo(IBorder border)
        {
            if (border is not DetailedBorder)
                return false;
            if (Thickness != border.Thickness)
                return false;
            var detailedBorder = (DetailedBorder)border;

            if (_borderChars.TlBorder != detailedBorder._borderChars.TlBorder)
                return false;
            if (_borderChars.TrBorder != detailedBorder._borderChars.TrBorder)
                return false;
            if (_borderChars.BlBorder != detailedBorder._borderChars.BlBorder)
                return false;
            if (_borderChars.BrBorder != detailedBorder._borderChars.BrBorder)
                return false;
            if (_borderChars.TBorder != detailedBorder._borderChars.TBorder)
                return false;
            if (_borderChars.BBorder != detailedBorder._borderChars.BBorder)
                return false;
            if (_borderChars.LBorder != detailedBorder._borderChars.LBorder)
                return false;
            if (_borderChars.RBorder != detailedBorder._borderChars.RBorder)
                return false;

            return true;
        }

        public IScreenDisplay GetDisplay(ScreenDisplayBuilder screenDisplayBuilder)
        {
            IScreenDisplay screenDisplay = screenDisplayBuilder.Build();
            AddBorder(screenDisplay);
            return screenDisplay;
        }

        private void AddBorder(IScreenDisplay screenDisplay)
        {
            screenDisplay.AddBorder(Thickness, _borderChars);
        }
    }
}
