using System;
using DotNetDns.Common.Records;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Records
{
    [TestFixture]
    public class ResourceRecordTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "-1 seconds is not a valid time to live. Value must be positive.")]
        public void Negative_Time_To_Live_Seconds_Throws()
        {
            new TestRecord
            {
                TimeToLiveSeconds = -1
            };
        }

        private class TestRecord : ResourceRecord
        {
        }
    }
}