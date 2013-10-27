using System.Collections.Generic;

namespace DotNetDns.Common.DomainNames
{
    public interface ITopLevelDomains
    {
        IList<string> GetAll();
        bool IsNotKnown(string topLevelDomain);
    }
}