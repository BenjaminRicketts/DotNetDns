using System;
using DotNetDns.Bootstrapper.Ioc.Attributes;
using Fasterflect;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace DotNetDns.Bootstrapper.Ioc.Conventions
{
    public class SingletonConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (TypeIsASingleton(type))
                registry.For(type).Singleton();
        }

        private bool TypeIsASingleton(Type type)
        {
            return type.Attribute<SingletonAttribute>() != null;
        }
    }
}