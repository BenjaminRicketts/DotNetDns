using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class CNameRecordTests : BaseResourceRecordTests<CNameRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.CNAME; } }

        [Test]
        public void Content_Returns_Canonical_Name()
        {
            Record.CanonicalName = "domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.CanonicalName));
        }
    }
}