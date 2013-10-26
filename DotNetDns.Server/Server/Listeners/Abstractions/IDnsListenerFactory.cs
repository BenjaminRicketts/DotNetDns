using System.Collections.Generic;

namespace DotNetDns.Server.Server.Listeners
{
    public interface IDnsListenerFactory
    {
        IList<IDnsListener> CreateListeners();
    }
}