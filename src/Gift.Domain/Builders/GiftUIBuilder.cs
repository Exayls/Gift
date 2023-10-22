using System;
using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;

namespace Gift.Domain.Builders
{
    /// <summary>
    /// Build GiftUI with Bound(20, 60) as default
    /// </summary>
    public class GiftUIBuilder
    {
        private Bound _bound;
        private IBorder _border;

        /// <summary>
        /// Get GiftUI instance with Bound(20, 60) as default
        /// </summary>
        public GiftUIBuilder()
        {
            if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
            {
                _bound = new Bound(Console.WindowHeight, Console.WindowWidth);

            }
            else
            {
                _bound = new Bound(0, 0);
            }
            _border = new NoBorder();
        }
        /// <summary>
        /// Set Bound parameter for the builder
        /// </summary>
        /// <param name="bound"></param>
        /// <returns>GiftUIBuilder instance</returns>
        public GiftUIBuilder WithBound(Bound bound)
        {
            _bound = bound;
            return this;
        }

        /// <summary>
        /// Get instance of GiftUI
        /// </summary>
        /// <returns>GiftUI instance</returns>
        public GiftUI Build()
        {
            return new GiftUI(_bound, _border);
        }

        public GiftUIBuilder WithBorder(IBorder border)
        {
            _border = border;
            return this;
        }
    }
}
