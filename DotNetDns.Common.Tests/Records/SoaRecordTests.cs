using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class SoaRecordTests : BaseResourceRecordTests<SoaRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.SOA; } }

        [Test]
        public void Content_Returns_Correctly_Formatted_Properties()
        {
            Record.PrimaryNameserver = "ns.domainname.com";
            Record.ResponsibleMailBox = "mail.domainname.com";
            Record.SerialNumber = 12345;
            Record.RefreshSeconds = 500;
            Record.RetrySeconds = 1000;
            Record.ExpirySeconds = 1500;
            Record.MinimumTimeToLiveSeconds = 2000;

            var expectedContent = "ns.domainname.com mail.domainname.com 12345 500 1000 1500 2000";

            Assert.That(Record.Content, Is.EqualTo(expectedContent));
        }
    }
}