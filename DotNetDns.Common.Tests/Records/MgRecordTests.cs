using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MgRecordTests : BaseResourceRecordTests<MgRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MG; } }

        [Test]
        public void Content_Returns_Mail_Group()
        {
            Record.MailGroup = "mail.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.MailGroup));
        }
    }
}