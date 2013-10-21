using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class PtrRecordTests : BaseResourceRecordTests<PtrRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.PTR; } }

        [Test]
        public void Content_Returns_Pointer()
        {
            Record.Pointer = "domainname.com";

            Assert.That(Record.Content, Is.EqualTo(Record.Pointer));
        }
    }
}