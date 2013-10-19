using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class NsRecordTests : BaseResourceRecordTests<NsRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.NS; } }

        [Test]
        public void Content_Returns_Nameserver()
        {
            Record.Nameserver = "ns.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.Nameserver));
        }
    }
}