namespace Gift.Domain.Builders
{
    public interface IBuilder<TProduct>
    {
        public TProduct Build();
    }
}
