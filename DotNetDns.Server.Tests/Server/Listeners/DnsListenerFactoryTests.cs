using System.Linq;
using DotNetDns.Server.Server.Listeners;
using DotNetDns.Server.Settings;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Server.Tests.Server.Listeners
{
    [TestFixture]
    public class DnsListenerFactoryTests
    {
        [Test]
        public void Factory_Returns_A_Udp_Listener()
        {
            var settings = new Mocker<IDnsServerSettings>().ToEntity();
            var factory = new DnsListenerFactory(settings);
            var hasUdpListener = factory
                                    .CreateListeners()
                                    .Any(listener => listener.GetType() == typeof(UdpListener));

            Assert.That(hasUdpListener, Is.True); 
        }
    }
}