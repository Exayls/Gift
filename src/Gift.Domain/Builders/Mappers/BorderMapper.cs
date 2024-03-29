﻿
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
                if (borderStr.ToLower() == "simple")
                {
                    borderOption = BorderOption.Simple;
                }
                else if (borderStr.ToLower() == "heavy")
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
