using System;
using DotNetDns.Common.Records;
using Fasterflect;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MfRecordTests : BaseResourceRecordTests<MfRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MF; } }

        [Test]
        public void Md_Record_Is_Marked_As_Obsolete()
        {
            var expectedMessage = "Obsolete - use an MX record.";
            var attribute = typeof(MfRecord).Attribute<ObsoleteAttribute>();

            Assert.That(attribute.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Content_Returns_Mail_Forwarder()
        {
            Record.MailForwarder ="mail.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.MailForwarder));
        }
    }
}