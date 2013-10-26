using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DotNetDns.Bootstrapper.Ioc;

namespace DotNetDns.Server
{
    public static class Program
    {
        public static void Main()
        {
            StructureMap.Bootstrap();

            System.ServiceProcess.ServiceBase.Run(new Service());
        }
    }
}