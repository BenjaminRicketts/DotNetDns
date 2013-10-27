using System;
using System.Linq;

namespace DotNetDns.Common.DomainNames
{
    public class DomainNameValidator
    {
        private const int MaxDomainNameLength = 253;
        private const int MaxLabelLength = 63;

        private readonly ITopLevelDomains _topLevelDomains;

        public DomainNameValidator(ITopLevelDomains topLevelDomains)
        {
            _topLevelDomains = topLevelDomains;
        }

        public void ValidateDomainName(string domainName)
        {
            ThrowIfTopLevelDomainIsInvalid(
                ThrowIfDomainNameIsTooLong(
                    ThrowIfLabelIsTooLong(
                        ThrowIfNullOrEmpty(domainName))));
        }

        private void Throw(string message)
        {
            throw new Exception(message);
        }

        private string ThrowIfDomainNameIsTooLong(string domainName)
        {
            if (domainName.Length > MaxDomainNameLength)
                Throw(string.Format("The domain name '{0}' is too long. Domain names may only be upto 253 characters in length.", domainName));

            return domainName;
        }

        private string ThrowIfLabelIsTooLong(string domainName)
        {
            foreach (var label in domainName.Split('.'))
            {
                if (label.Length > MaxLabelLength)
                    Throw(string.Format("The label '{0}' is too long. Labels may only be upto 63 characters in length.", label));
            }

            return domainName;
        }

        private string ThrowIfNullOrEmpty(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
                Throw("A domain name cannot be null or empty.");

            return domainName;
        }

        private string ThrowIfTopLevelDomainIsInvalid(string domainName)
        {
            var labels = domainName.Split('.').ToList();

            if (labels.Count > 0)
            {
                var topLevelDomain = labels.Last();

                if (_topLevelDomains.IsNotKnown(topLevelDomain))
                    Throw(string.Format("The top level domain '{0}' is invalid.", topLevelDomain));
            }

            return domainName;
        }
    }
}