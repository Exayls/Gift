
using System;
using Gift.Domain.UIModel.Border;

namespace Gift.Domain.Builders.Mappers
{
    public class BorderMapper : IBorderMapper
    {
        public IBorder ToBorder(string borderStr)
        {
            try
            {
                BorderOption borderOption;
                if (borderStr.Equals("simple", StringComparison.OrdinalIgnoreCase))
                {
                    borderOption = BorderOption.Simple;
                }
                else if (borderStr.Equals("heavy", StringComparison.OrdinalIgnoreCase))
                {
                    borderOption = BorderOption.Heavy;
                }
                else
                {
                    borderOption = BorderOption.GetBorderCharsFromFile(borderStr);
                }
                var border = new DetailedBorder(1, borderOption);
                return border;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"{borderStr} is not a valid parameter for WithBorder, it must be simple, heavy or a jsonfile containing border informations", e);
            }
        }
    }
}
