using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MrRecordTests : BaseResourceRecordTests<MrRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MR; } }

        [Test]
        public void Content_Returns_Mail_Rename()
        {
            Record.MailRename = "mail.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.MailRename));
        }
    }
}