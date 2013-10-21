using System;
using NUnit.Framework;

namespace DotNetDns.TestHelpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IntegrationTestsAttribute : CategoryAttribute
    {
        public IntegrationTestsAttribute()
            : base("Integration")
        {
        }
    }
}