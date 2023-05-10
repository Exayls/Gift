namespace Gift.SignalHandler.KeyInput
{
    public interface IKeyMapper
    {
        IList<IKeyMapping> GetMapping();
    }
}