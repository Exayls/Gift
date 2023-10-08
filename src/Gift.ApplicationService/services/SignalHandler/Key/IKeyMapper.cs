using System.Collections.Generic;

namespace Gift.ApplicationService.services.SignalHandler.Key
{
    public interface IKeyMapper
    {
        IList<IKeyMapping> GetMapping();
    }
}
