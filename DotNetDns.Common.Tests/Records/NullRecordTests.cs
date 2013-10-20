using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class NullRecordTests : BaseResourceRecordTests<NullRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.NULL; } }

        [Test]
        public void Content_Returns_Data()
        {
            Record.Data = "Some record data";

            Assert.That(Record.Content, Is.EqualTo(Record.Data));
        }
    }
}