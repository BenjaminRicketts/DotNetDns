using System;
using DotNetDns.Server.Server.Listeners;
using NUnit.Framework;

namespace DotNetDns.Server.Tests.Server.Listeners
{
    [TestFixture]
    public class UdpListenerTests
    {
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "No DNS server settings have been found.")]
        public void Constructing_With_No_Settings_Throws()
        {
            new UdpListener(null);
        }
    }
}