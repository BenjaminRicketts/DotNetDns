using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MxRecordTests : BaseResourceRecordTests<MxRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MX; } }

        [Test]
        public void Content_Returns_Preference_And_Exchange()
        {
            Record.Preference = 10;
            Record.Exchange = "exchange.domainname.com";

            Assert.That(Record.Content, Is.EqualTo("10 exchange.domainname.com"));
        }
    }
}