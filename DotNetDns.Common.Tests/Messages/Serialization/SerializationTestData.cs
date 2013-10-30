using System.Collections.Generic;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    public abstract class SerializationTestData
    {
        public IEnumerable<TestCaseData> UnsignedShortData
        {
            get
            {
                return new List<TestCaseData>
                {
                    new TestCaseData(new byte[] { 0, 1 }, (ushort)1, true),
                    new TestCaseData(new byte[] { 1, 0 }, (ushort)256, true),
                    new TestCaseData(new byte[] { 0, 1 }, (ushort)256, false),
                    new TestCaseData(new byte[] { 1, 0 }, (ushort)1, false)
                };
            }
        }
    }
}