using Gift.Domain.UIModel;
using Gift.Domain.UIModel.Border;
using Gift.Domain.UIModel.MetaData;

namespace Gift.src.Builders
{
    /// <summary>
    /// Build GiftUI with Bound(20, 60) as default
    /// </summary>
    public class GiftUIBuilder
    {
        private Bound Bound;

        /// <summary>
        /// Get GiftUI instance with Bound(20, 60) as default
        /// </summary>
        public GiftUIBuilder()
        {
            Bound = new Bound(20, 60);
        }
        /// <summary>
        /// Set Bound parameter for the builder
        /// </summary>
        /// <param name="bound"></param>
        /// <returns>GiftUIBuilder instance</returns>
        public GiftUIBuilder WithBound(Bound bound)
        {
            Bound = bound;
            return this;
        }

        /// <summary>
        /// Get instance of GiftUI
        /// </summary>
        /// <returns>GiftUI instance</returns>
        public GiftUI Build()
        {
            return new GiftUI(Bound, new NoBorder());
        }
    }
}
