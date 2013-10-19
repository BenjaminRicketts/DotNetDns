using System.Net;
using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class ARecordTests : BaseResourceRecordTests<ARecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.A; } }

        [Test]
        public void Content_Returns_Ip_Address()
        {
            Record.IpAddress = IPAddress.Loopback;

            Assert.That(Record.Content, Is.EqualTo("127.0.0.1"));
        }
    }
}