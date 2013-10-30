using System;
using DotNetDns.Common.Messages.Serialization;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    [TestFixture]
    public class MessageSerializerTests
    {
        private Mocker<IEndianessChecker> _endianessCheckerMocker;
        private HeaderBytes _headerBytes;
        private MessageSerializer _serializer;

        [SetUp]
        public void SetupTest()
        {
            _endianessCheckerMocker = new Mocker<IEndianessChecker>()
                                            .With(checker => checker.IsLittleEndianSystem, true);
                                            
            _headerBytes = new HeaderBytes();
            _serializer = new MessageSerializer(_endianessCheckerMocker.ToEntity());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Null bytes cannot be deserialized into a Message.")]
        public void Null_Bytes_Throw()
        {
            _serializer.DeserializeFromBytes(null);
        }

        [Test]
        [TestCase(new byte[] { 0, 1 }, (ushort)1)]
        [TestCase(new byte[] { 1, 0 }, (ushort)256)]
        public void Message_Id_Is_Correctly_Deserialized(byte[] idBytes, ushort expectedId)
        {
            var bytes = _headerBytes
                            .WithIdBytes(idBytes)
                            .ToArray();

            var message = _serializer.DeserializeFromBytes(bytes);

            Assert.That(message.Id, Is.EqualTo(expectedId));
        }

        [Test]
        [TestCase(new byte[] { 0, 0 }, true)]
        [TestCase(new byte[] { 128, 0 }, false)]
        public void Message_Type_Is_Correctly_Deserialized(byte[] flagBytes, bool expectedValue)
        {
            var bytes = _headerBytes
                            .WithFlagBytes(flagBytes)
                            .ToArray();

            var message = _serializer.DeserializeFromBytes(bytes);

            Assert.That(message.IsAQuery, Is.EqualTo(expectedValue));
        }
    }
}