using System;
using System.Diagnostics;
using System.Linq;
using StructureMap;
using StructureMap.Graph;

namespace DotNetDns.Bootstrapper.Ioc
{
    public class StructureMap
    {
        public static void Bootstrap()
        {
            new StructureMap().Initialise();
        }

        public void Initialise()
        {
            ObjectFactory.Initialize(factory =>
            {
                factory.Scan(scanner =>
                {
                    scanner.WithDefaultConventions();
                    ScanSolutionAssemblies(scanner);
                });
            });

            AssertConfigurationIsValid();
        }

        [Conditional("DEBUG")]
        private void AssertConfigurationIsValid()
        {
            ObjectFactory.AssertConfigurationIsValid();
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