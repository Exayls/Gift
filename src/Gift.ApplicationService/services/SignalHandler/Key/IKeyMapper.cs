using System.Collections.Generic;

namespace Gift.ApplicationService.Services.SignalHandler.Key
{
    public interface IKeyMapper
    {
        IList<IKeyMapping> GetMapping();
    }
}
