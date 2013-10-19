using DotNetDns.Common.Records;
using NUnit.Framework;
using Fasterflect;
using System;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class MdRecordTests : BaseResourceRecordTests<MdRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.MD; } }

        [Test]
        public void Content_Returns_Mail_Destination()
        {
            Record.MailDestination = "mail.domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.MailDestination));
        }

        [Test]
        public void Md_Record_Is_Marked_As_Obsolete()
        {
            var expectedMessage = "Obsolete - use an MX record.";
            var attribute = typeof(MdRecord).Attribute<ObsoleteAttribute>();

            Assert.That(attribute.Message, Is.EqualTo(expectedMessage));
        }
    }
}