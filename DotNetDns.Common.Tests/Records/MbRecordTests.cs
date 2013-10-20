using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MbRecordTests : BaseResourceRecordTests<MbRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MB; } }

        [Test]
        public void Content_Returns_Mail_Box()
        {
            Record.MailBox = "mail.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.MailBox));
        }
    }
}