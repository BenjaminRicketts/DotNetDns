using DotNetDns.Bootstrapper.Ioc.Attributes;
using Fasterflect;
using NUnit.Framework;

namespace DotNetDns.TestHelpers.Assertions
{
    public class ClassAssertions
    {
        public static void AssertClassIsSingleton<T>() where T : class
        {
            var attribute = typeof(T).Attribute<SingletonAttribute>();

            Assert.That(attribute, Is.Not.Null);
        }
    }
}