using System;

namespace DotNetDns.Bootstrapper.Ioc.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class SingletonAttribute : Attribute
    {
    }
}