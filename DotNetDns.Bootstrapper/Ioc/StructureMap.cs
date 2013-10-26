using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using StructureMap;
using StructureMap.Graph;

namespace DotNetDns.Bootstrapper.Ioc
{
    public class StructureMap
    {
        private StructureMap()
        {
            Initialise();
            AssertConfigurationIsValid();
        }

        public static void Bootstrap()
        {
            new StructureMap();
        }

        public void Initialise()
        {
            ObjectFactory.Initialize(factory =>
            {
                factory.Scan(scanner =>
                {
                    AddConventions(scanner);
                    ScanSolutionAssemblies(scanner);
                });
            });
        }

        private void AddConventions(IAssemblyScanner scanner)
        {
            scanner.WithDefaultConventions();

            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IRegistrationConvention).IsAssignableFrom(type))
                .ToList()
                .ForEach(type => scanner.With(CreateConvention(type)));
        }

        [Conditional("DEBUG")]
        private void AssertConfigurationIsValid()
        {
            ObjectFactory.AssertConfigurationIsValid();
        }

        private IRegistrationConvention CreateConvention(Type type)
        {
            return (IRegistrationConvention)Activator.CreateInstance(type);
        }

        private void ScanSolutionAssemblies(IAssemblyScanner scanner)
        {
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith("DotNetDns."))
                .ToList()
                .ForEach(assembly => scanner.Assembly(assembly));
        }
    }
}