using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MInfoRecordTests : BaseResourceRecordTests<MInfoRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MINFO; } }

        [Test]
        public void Content_Returns_Responsible_And_Error_Mailboxes()
        {
            Record.ResponsibleMailBox = "responsible.domainname.com";
            Record.ErrorMailBox = "error.domainname.com";

            Assert.That(Record.Content, Is.EqualTo("responsible.domainname.com error.domainname.com"));
        }
    }
}