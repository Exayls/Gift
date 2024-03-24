namespace Gift.Domain.Builders.UIModel
{
    public interface IBuilder<TProduct>
    {
        public TProduct Build();
    }
}
