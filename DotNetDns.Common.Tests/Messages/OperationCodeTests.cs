using DotNetDns.Common.Messages;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages
{
    [TestFixture]
    public class OperationCodeTests
    {
        [Test]
        [TestCase(OperationCode.StandardQuery, (byte)0)]
        [TestCase(OperationCode.InverseQuery, (byte)1)]
        [TestCase(OperationCode.Status, (byte)2)]
        public void Operation_Code_Maps_To_Correct_Byte_Value(OperationCode operationCode, byte expectedValue)
        {
            Assert.That((byte)operationCode, Is.EqualTo(expectedValue));
        }
    }
}