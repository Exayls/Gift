using Gift.Domain.UIModel.Element;
using Gift.Domain.UIModel.MetaData;
using Gift.Domain.ServiceContracts;
using System;

namespace Gift.Domain.Services
{
    public class TrueElementSizeCalculator : IElementSizeCalculator
    {
        private readonly IRepository _repository;

        public TrueElementSizeCalculator(IRepository repository)
        {
            _repository = repository;
        }
        public Size GetTrueSize(Container element)
        {
            var trueHeight = 0;
            var trueWidth = 0;
            if (element.Size.Height < 0)
            {
                trueHeight = GetClosestParentSize(element).Height;
            }
            else
            {
                trueHeight = element.Height;
            }
            if (element.Size.Width < 0)
            {
                trueWidth = GetClosestParentSize(element).Width;
            }
            else
            {
                trueWidth = element.Width;
            }
            return new Size(trueHeight, trueWidth);
        }

        private Size GetClosestParentSize(Container element)
        {
            Container? parent = _repository.GetParent(element);
            if (parent is null)
            {
                return new Size(Console.WindowHeight, Console.WindowWidth);
            }
            var parentSize = GetTrueSize(parent);
            int thickness = parent.Border.Thickness;
            return new Size(parentSize.Height - thickness * 2, parentSize.Width - thickness * 2);
        }

        public Size GetTrueSize(UIElement element)
        {
            return new Size(element.Height, element.Width);
        }
    }
}
