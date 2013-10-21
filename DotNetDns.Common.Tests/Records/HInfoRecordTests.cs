using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class HInfoRecordTests : BaseResourceRecordTests<HInfoRecord>
    {
        protected override RecordType ExpectedType { get { return RecordType.HINFO; } }

        [Test]
        public void Content_Returns_Cpu_And_Operating_System()
        {
            Record.Cpu = "cpu";
            Record.OperatingSystem = "operating system";

            Assert.That(Record.Content, Is.EqualTo("cpu operating system"));
        }
    }
}