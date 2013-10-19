using System;
using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class ResourceRecordTests
    {
        private TestRecord _record;

        [SetUp]
        public void SetupTest()
        {
            _record = new TestRecord();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "-1 seconds is not a valid time to live. Value must be positive.")]
        public void Negative_Time_To_Live_Seconds_Throws()
        {
            _record.TimeToLiveSeconds = -1;
        }

        [Test]
        public void Internet_Class_Is_Set_By_Default()
        {
            Assert.That(_record.Class, Is.EqualTo(RecordClass.Internet));
        }

        [Test]
        public void Content_Length_Returns_The_Correct_Length()
        {
            _record.Data = "Record content";

            Assert.That(_record.ContentLength, Is.EqualTo(_record.Content.Length));
        }

        private class TestRecord : ResourceRecord
        {
            public override string Content { get { return Data; } }

            public string Data { get; set; }

            public override RecordType Type { get { return RecordType.A; } }
        }
    }
}