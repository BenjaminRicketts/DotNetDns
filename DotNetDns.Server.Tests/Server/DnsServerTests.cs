using System;
using System.Collections.Generic;
using DotNetDns.Server.Server;
using DotNetDns.Server.Server.Listeners;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Server.Tests.Server
{
    [TestFixture]
    public class DnsServerTests
    {
        [Test]
        [TestCaseSource("InvalidListeners")]
        [ExpectedException(typeof(Exception), ExpectedMessage = "DNS server cannot listen for DNS queries without any listeners configured.")]
        public void Initialising_Dns_Server_With_No_Listeners_Configured_Throws(IList<IDnsListener> listeners)
        {
            new DnsServer(listeners);
        }

        [Test]
        public void Starting_Dns_Server_Starts_Listeners()
        {
            var mockListener = new Mocker<IDnsListener>();
            var server = new DnsServer(new List<IDnsListener> { mockListener.ToEntity() });

            server.StartListening();

            mockListener.AssertWasCalledOnce(x => x.StartListening());
        }

        private IEnumerable<TestCaseData> InvalidListeners
        {
            get
            {
                return new List<TestCaseData>
                {
                    new TestCaseData(null),
                    new TestCaseData(new List<IDnsListener>())
                };
            }
        }
    }
}