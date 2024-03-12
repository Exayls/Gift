using System;
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
            if (!(border is DetailedBorder))
                return false;
            if (Thickness != border.Thickness)
                return false;
            var detailedBorder = (DetailedBorder)border;

            if (_borderChars.tlBorder != detailedBorder._borderChars.tlBorder)
                return false;
            if (_borderChars.trBorder != detailedBorder._borderChars.trBorder)
                return false;
            if (_borderChars.blBorder != detailedBorder._borderChars.blBorder)
                return false;
            if (_borderChars.brBorder != detailedBorder._borderChars.brBorder)
                return false;
            if (_borderChars.tBorder != detailedBorder._borderChars.tBorder)
                return false;
            if (_borderChars.bBorder != detailedBorder._borderChars.bBorder)
                return false;
            if (_borderChars.lBorder != detailedBorder._borderChars.lBorder)
                return false;
            if (_borderChars.rBorder != detailedBorder._borderChars.rBorder)
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
