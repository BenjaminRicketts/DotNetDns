using System;
using DotNetDns.Common.Messages.Serialization;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    [TestFixture]
    public class MessageSerializerTests
    {
        private MessageSerializer _serializer;

        [SetUp]
        public void SetupSerializer()
        {
            _serializer = new MessageSerializer();
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Null bytes cannot be deserialized into a Message.")]
        public void Null_Bytes_Throw()
        {
            _serializer.DeserializeFromBytes(null);
        }


    }
}