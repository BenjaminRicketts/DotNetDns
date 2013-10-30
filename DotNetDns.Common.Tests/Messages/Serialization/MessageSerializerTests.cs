using System;
using DotNetDns.Common.Messages.Serialization;
using DotNetDns.TestHelpers;
using NUnit.Framework;

namespace DotNetDns.Common.Tests.Messages.Serialization
{
    [TestFixture]
    public class MessageSerializerTests : SerializationTestData
    {
        private Mocker<IEndianessChecker> _endianessCheckerMocker;
        private MessageSerializer _serializer;

        [SetUp]
        public void SetupSerializer()
        {
            _endianessCheckerMocker = new Mocker<IEndianessChecker>();
            _serializer = new MessageSerializer(_endianessCheckerMocker.ToEntity());
        }

        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Null bytes cannot be deserialized into a Message.")]
        public void Null_Bytes_Throw()
        {
            _serializer.DeserializeFromBytes(null);
        }

        [Test]
        [TestCaseSource("UnsignedShortData")]
        public void Message_Id_Is_Correctly_Deserialized(byte[] idBytes, ushort expectedId, bool isLittleEndian)
        {
            SetToLittleEndianess(isLittleEndian);

            var bytes = new HeaderBytes()
                                .WithIdBytes(idBytes)
                                .ToArray();

            var message = _serializer.DeserializeFromBytes(bytes);

            Assert.That(message.Id, Is.EqualTo(expectedId));
        }

        private void SetToLittleEndianess(bool isLittleEndian)
        {
            _endianessCheckerMocker.With(checker => checker.IsLittleEndianSystem, isLittleEndian);
        }
    }
}